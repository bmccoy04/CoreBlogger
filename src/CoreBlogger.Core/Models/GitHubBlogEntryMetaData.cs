using System;
using System.Collections.Generic;

namespace CoreBlogger.Core.Models
{
    public class GitHubBlogEntryMetaData
    {
        private string _metaData;

        public GitHubBlogEntryMetaData(string metaData)
        {
            _metaData = metaData;
        }

        public string Author {
            get 
            {                
                return getContentByPosition(1);
            }
        }

        public string Title {
            get {
                return getContentByPosition(2);
            }
        }

        public DateTime Date {
            get {                
                return Convert.ToDateTime(getContentByPosition(3));
            }
        }

        public IList<string> Tags {
            get {                
                return getContentByPosition(4).Split(',');
            }
        }

        public bool Live {
            get {
                var splitContent = getContentByPosition(5);
                
                if(splitContent == "Yes")
                    return true;

                return false;
            }
        }

        private string getContentByPosition(int position)
        {
            var meta = _metaData.Split(new string[]{"::::"}, StringSplitOptions.None);

            if(meta.Length != 3)
                return " ";
            
            var content = meta[1].Split(new string[]{"::"}, StringSplitOptions.None);

            if(content.Length < position + 1)
                return " ";

            var item = content[position].Split(':');

            if(item.Length != 2)
                return "not 2";

            return item[1].Trim();            
        }

    }
}