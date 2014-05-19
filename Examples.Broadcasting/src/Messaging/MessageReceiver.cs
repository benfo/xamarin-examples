using Android.Content;
using System;

namespace Examples.Broadcasting.Messaging
{
    public class MessageReceiver : BroadcastReceiver
    {
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        public override void OnReceive(Context context, Intent intent)
        {
            var data = intent.GetStringExtra("message");

            OnMessageReceived(new MessageReceivedEventArgs(data));
        }

        protected virtual void OnMessageReceived(MessageReceivedEventArgs e)
        {
            var handler = MessageReceived;
            if (handler != null) handler(this, e);
        }
    }
}