## Android: Broadcast and BroadcastReceiver Example

This example demonstrates one way of doing communication between a service and activity by sending and receiving broadcasts. The application also makes use of a custom permission to limit access of the broadcast to only the intended receiver.

The activity can do the following:

- Start the service
- Stop the service
- Send a message to the service
- Receive messages from the service

The service can do the following:

- Receive a message from the activity
- Send the received message back to the activity
