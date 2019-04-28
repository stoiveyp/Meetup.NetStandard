using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Meetup.NetStandard.Request.Photos
{
    public class UpdatePhotoRequest:MeetupFileRequest
    {
        public Stream Photo { get; }

        public bool? SetAsMain { get; set; }

        public bool? SyncGroupPhotos { get; set; }
        public UpdatePhotoRequest(Stream photo)
        {
            Photo = photo;
        }

        public override IEnumerable<KeyValuePair<string, Stream>> GetFiles()
        {
            yield return new KeyValuePair<string, Stream>("photo", Photo);
        }

        public override Dictionary<string, string> AsDictionary()
        {
            var dict = new Dictionary<string, string>();

            if (SetAsMain.HasValue)
            {
                dict.Add("main",SetAsMain.Value.ToString());
            }

            if (SyncGroupPhotos.HasValue)
            {
                dict.Add("sync_photo", SyncGroupPhotos.Value.ToString());
            }

            return dict;
        }
    }
}
