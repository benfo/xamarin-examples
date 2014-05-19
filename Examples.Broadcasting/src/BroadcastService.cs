using Android.App;
using Android.Content;
using Android.OS;
using Examples.Broadcasting.Messaging;

namespace Examples.Broadcasting
{
    [Service]
    [IntentFilter(new[] { Actions.ActionStart, Actions.ActionStop })]
    public class BroadcastService : Service
    {
        private MessageReceiver messageReceiver;
        private MessageSender messageSender;

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override void OnCreate()
        {
            base.OnCreate();

            messageSender = new MessageSender(this);

            // Receive message
            messageReceiver = new MessageReceiver();
			messageReceiver.MessageReceived += (sender, args) => messageSender.SendMessage(Actions.ActionFromService, "Your message: " + args.Message);
            RegisterReceiver(messageReceiver, new IntentFilter(Actions.ActionToService));
        }

        public override void OnDestroy()
        {
            messageSender.SendMessage(Actions.ActionFromService, "Stopping service");
            UnregisterReceiver(messageReceiver);

            base.OnDestroy();
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            messageSender.SendMessage(Actions.ActionFromService, "Service started");

            return base.OnStartCommand(intent, flags, startId);
        }
    }
}