import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

import * as signalR from '@microsoft/signalr';


@Component({
  selector: 'app-chat-hub',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './chat-hub.component.html',
  styleUrl: './chat-hub.component.css'
})
export class ChatHubComponent {
  title = 'Assesment6'
  message: string = "";
  messages: string[] = [];

  userName: string = "";
  isUserLoggedIn: boolean = false;

  private _chatHubConnection: signalR.HubConnection | null | undefined;

  ngOnInit(): void {
    // Fetch username from local storage
    const storedUser = localStorage.getItem('logindata') || '{}'
    if (storedUser) {
      const parseuser = JSON.parse(storedUser);
      this.userName = parseuser.UserName;
      this.isUserLoggedIn = true;
    } else {
      alert('User not logged in. Redirecting to login page.');
      // Optionally redirect to login
    }

    // Initialize SignalR connection
    this._chatHubConnection = new signalR.HubConnectionBuilder()
      .withUrl(`https://localhost:7178/chathub`, {
        timeout: 600000
      })
      .configureLogging(signalR.LogLevel.Error)
      .build();

    this.startHubConnection(this._chatHubConnection);

    // Listen for messages from the backend
    this._chatHubConnection.on('messageRecieved', (message: string, user: string) => {
      this.messages.push(`${user}: ${message}`);
      this.message = '';
    });
  }

  onMessageSent() {
    debugger
    if (this.message && this.userName) {
      this._chatHubConnection?.invoke('MessageSent', this.message, this.userName)
        .catch(err => console.error('Error sending message:', err));
    } else {
      alert('Message or username is missing!');
    }
  }

  private startHubConnection(hubConnection: signalR.HubConnection): Promise<signalR.HubConnection> {
    return hubConnection
      .start()
      .then(() => {
        console.log('Connection started. Connection ID:', hubConnection.connectionId);
        return hubConnection;
      })
      .catch(err => {
        console.error('Error while starting connection: ', err);
        return hubConnection;
      });
  }

}
