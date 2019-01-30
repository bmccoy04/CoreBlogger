
using System;
using Xunit;
using Moq;
using CoreBlogger.Core.Handlers;
using CoreBlogger.Core.Providers;
using Microsoft.Extensions.Logging;
using CoreBlogger.Core.Interfaces;
using CoreBlogger.Core.Queries;
using CoreBlogger.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace CoreBlogger.Tests.Core.Handlers
{
    public class GetActiveBlogEntriesHandlerTests
    {
        public const string activeContent = @"::::
                                              ::  Author: Bryan McCoy
                                              ::  Title: Test !
                                              ::  Date: 12/9/2018
                                              ::  Tags: First Post, Test
                                              ::  Live: Yes
                                              ::::";
        public const string notActiveContent = @"::::
                                              ::  Author: Bryan McCoy
                                              ::  Title: Test !
                                              ::  Date: 12/9/2018
                                              ::  Tags: First Post, Test
                                              ::  Live: No
                                              ::::";
        [Fact]
        public void ConstructorTest()
        {
            var logger = new Mock<ILogger<GetActiveBlogEntriesHandler>>();
            var cachedGitHubEntryProvider = new Mock<ICachedGitHubEntryProvider>();
            var result = new GetActiveBlogEntriesHandler(logger.Object, cachedGitHubEntryProvider.Object);

            Assert.NotNull(result);
        }

        [Fact]        
        public void HandleReturnsListSuccess()
        {
            var logger = new Mock<ILogger<GetActiveBlogEntriesHandler>>();
            var cachedGitHubEntryProvider = new Mock<ICachedGitHubEntryProvider>();
            var handler = new GetActiveBlogEntriesHandler(logger.Object, cachedGitHubEntryProvider.Object);

            var request = new GetActiveBlogEntriesQuery();
            var cancelationToken = new System.Threading.CancellationToken();

            var gitHubEntry = new GitHubBlogEntry();
            gitHubEntry.SetContent(activeContent);

            var expected = new List<GitHubBlogEntry>{gitHubEntry};

            cachedGitHubEntryProvider.Setup(x => x.GetEntries()).ReturnsAsync(expected);

            var actual = handler.Handle(request, cancelationToken).Result;

            Assert.Equal(expected, actual);
        }
        
        [Fact]        
        public void HandleReturnsEmptyListSuccess()
        {
            var logger = new Mock<ILogger<GetActiveBlogEntriesHandler>>();
            var cachedGitHubEntryProvider = new Mock<ICachedGitHubEntryProvider>();
            var handler = new GetActiveBlogEntriesHandler(logger.Object, cachedGitHubEntryProvider.Object);

            var request = new GetActiveBlogEntriesQuery();
            var cancelationToken = new System.Threading.CancellationToken();

            var gitHubEntry = new GitHubBlogEntry();
            gitHubEntry.SetContent(notActiveContent);

            var expected = new List<GitHubBlogEntry>();

            cachedGitHubEntryProvider.Setup(x => x.GetEntries()).ReturnsAsync(new List<GitHubBlogEntry>{gitHubEntry});

            var actual = handler.Handle(request, cancelationToken).Result;
            
            Assert.Equal(expected, actual);
        }
    }
}