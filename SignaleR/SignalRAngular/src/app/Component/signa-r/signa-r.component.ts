import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import * as signalR from '@microsoft/signalr';

@Component({
  selector: 'app-signa-r',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './signa-r.component.html',
  styleUrl: './signa-r.component.css'
})
export class SignaRComponent {

  title = 'SingalRAngular';
  message: string = "";
  messages: string[] = [];

  userName: string = "";
  isUserLoggedIn: boolean = false;

  private _chatHubConnection: signalR.HubConnection | null | undefined;

  ngOnInit(): void {
    this._chatHubConnection = new signalR.HubConnectionBuilder()
      .withUrl(`https://localhost:7265/chathub`, {
        timeout: 600000
      })
      .configureLogging(signalR.LogLevel.Error)
      .build();

    this.startHubConnection(this._chatHubConnection);

    this._chatHubConnection.on("messageRecieved", (message: string, user: string) => {
      this.messages.push(`${user}: ${message}`);
      this.message = "";
    });
  }

  onLogin() {
    this.isUserLoggedIn = true;
  }

  onMessageSent() {
    this._chatHubConnection?.invoke("messageSent", this.message, this.userName);
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
