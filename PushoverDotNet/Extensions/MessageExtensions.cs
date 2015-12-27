using System;
using System.Collections.Specialized;

namespace PushoverDotNet.Extensions
{
    static class MessageExtensions
    {
        /// <summary>
        /// Get a dictionary of request arguments
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static NameValueCollection GetRequestValues(this IPushoverMessage message)
        {
            // Build up the request
            var values = new NameValueCollection
                       {
                           {"user", message.User},
                           {"message", message.Message}
                       };

            if (!String.IsNullOrEmpty(message.Device))
                values.Add("device", message.Device);

            if (!String.IsNullOrEmpty(message.Title))
                values.Add("title", message.Title);

            if (!String.IsNullOrEmpty(message.Url))
                values.Add("url", message.Url);

            if (!String.IsNullOrEmpty(message.UrlTitle))
                values.Add("url_title", message.UrlTitle);

            values.Add("priority", GetMessagePriority(message.Priority).ToString());

            if (message.Priority == MessagePriority.Emergency)
            {
                values.Add("retry",message.Retry.ToString());
                values.Add("expire",message.Expiration.ToString());
            }

            if (message.Timestamp != null)
                values.Add("timestamp", message.Timestamp.Value.ToEpoch().ToString());

            return values;
        }

        private static int GetMessagePriority(MessagePriority priority)
        {
            switch (priority)
            {
                case MessagePriority.High:
                    return 1;
                case MessagePriority.Emergency:
                    return 2;
                case MessagePriority.Normal:
                    return 0;
                case MessagePriority.Low:
                    return -1;
                case MessagePriority.Lowest:
                    return -2;
                default:
                    return 0;
            }
        }
    }
}
