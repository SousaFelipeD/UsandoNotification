namespace Pais.Domain.Notification
{
    /// <summary>
    /// 
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// 
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="message"></param>
        public Notification(string key, string message)
        {
            Key = key;
            Message = message;
        }
    }
}
