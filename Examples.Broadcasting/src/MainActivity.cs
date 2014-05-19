using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Examples.Broadcasting.Messaging;

namespace Examples.Broadcasting
{
    [Activity(Label = "Broadcasting", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private MessageReceiver messageReceiver;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var startService = FindViewById<Button>(Resource.Id.startService);
            var stopService = FindViewById<Button>(Resource.Id.stopService);
            var messageToService = FindViewById<EditText>(Resource.Id.messageToService);
            var sendToService = FindViewById<Button>(Resource.Id.sendToService);

            // Start/Stop Service
			startService.Click += (sender, args) => StartService(new Intent(Actions.ActionStart));
            stopService.Click += (sender, args) => StopService(new Intent(Actions.ActionStop));

            // Receive Message
            messageReceiver = new MessageReceiver();
            messageReceiver.MessageReceived += (sender, args) =>
            {
                var messageFromService = FindViewById<TextView>(Resource.Id.messageFromService);
                messageFromService.Text = args.Message;
            };
            RegisterReceiver(messageReceiver, new IntentFilter(Actions.ActionFromService));

            // Send Message
            var messageSender = new MessageSender(this);
			sendToService.Click += (sender, args) => messageSender.SendMessage(Actions.ActionToService, messageToService.Text);
        }

        protected override void OnDestroy()
        {
            StopService(new Intent(Actions.ActionStop));
            UnregisterReceiver(messageReceiver);

            base.OnDestroy();
        }
    }
}