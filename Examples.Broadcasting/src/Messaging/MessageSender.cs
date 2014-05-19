using Android.Content;

namespace Examples.Broadcasting.Messaging
{
    public class MessageSender
    {
        private readonly Context context;

        public MessageSender(Context context)
        {
            this.context = context;
        }

		public void SendMessage(string action, string message)
        {
			var intent = new Intent(action);
            intent.PutExtra("message", message);

            context.SendBroadcast(intent);
        }
    }
}