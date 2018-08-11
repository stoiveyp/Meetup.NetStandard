using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meetup.NetStandard.Request.Topics
{
    public class RecommendedGroupTopicRequest:MeetupRequest
    {
        public string Text { get; set; }
        public int[] OtherTopics { get; set; }
        public int[] ExcludeTopics { get; set; }
        public string LanguageCode { get; set; }
        public int? NumberOfResults { get; set; }

        public RecommendedGroupTopicRequest(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            Text = text;
        }

        public RecommendedGroupTopicRequest(IEnumerable<int> basedOnTopics)
        {
            var groupArray = basedOnTopics?.ToArray() ?? new int[] { };
            if (!groupArray.Any())
            {
                throw new ArgumentNullException(nameof(basedOnTopics));
            }

            OtherTopics = groupArray;
        }

        public override Dictionary<string, string> AsDictionary()
        {
            var dictionary = new Dictionary<string, string>
            {
                {"photo-host", "public"}
            };

            if (!string.IsNullOrWhiteSpace(Text))
            {
                dictionary.Add("text", Text);
            }

            if (OtherTopics?.Any() ?? false)
            {
                dictionary.Add("other_topics", string.Join(",", OtherTopics.Select(i => i.ToString()).ToArray()));
            }

            if (ExcludeTopics?.Any() ?? false)
            {
                dictionary.Add("exclude_topics", string.Join(",", ExcludeTopics.Select(t => t.ToString())));
            }

            if (!string.IsNullOrWhiteSpace(LanguageCode))
            {
                dictionary.Add("lang", LanguageCode);
            }

            if (NumberOfResults.HasValue)
            {
                dictionary.Add("page",NumberOfResults.Value.ToString());
            }

            return dictionary;
        }
    }
}
