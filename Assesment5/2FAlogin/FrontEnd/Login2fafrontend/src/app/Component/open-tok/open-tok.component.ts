import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import OT from '@opentok/client';

@Component({
  selector: 'app-open-tok',
  standalone: true,
  imports: [],
  templateUrl: './open-tok.component.html',
  styleUrl: './open-tok.component.css'
})
export class OpenTokComponent {
  // apiUrl = 'http://localhost:5000/api/video'; // Your backend API URL
  apiUrl = 'https://localhost:7276/api/OpenTok'
  session: any;
  publisher: any;
  archiveId: string | null = null;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.startSession();
  }

  startSession() {
    this.http.get(`${this.apiUrl}/create-session`).subscribe((res: any) => {
      const sessionId = res.sessionId;

      this.http.get(`${this.apiUrl}/generate-token?sessionId=${sessionId}`).subscribe((tokenRes: any) => {
        const token = tokenRes.token;
        this.session = OT.initSession('b669c86a', sessionId);

        this.session.connect(token, () => {
          this.publisher = OT.initPublisher('publisher');
          this.session.publish(this.publisher);

          this.session.on('streamCreated', (event: any) => {
            this.session.subscribe(event.stream, 'subscriber');
          });
        });
      });
    });
  }

  startScreenSharing() {
    this.publisher = OT.initPublisher('publisher', { videoSource: 'screen' });
    this.session.publish(this.publisher);
  }

  startRecording() {
    this.http.post(`${this.apiUrl}/start-recording`, { sessionId: this.session.sessionId }).subscribe((res: any) => {
      this.archiveId = res.archiveId;
    });
  }

  stopRecording() {
    if (!this.archiveId) {
      alert('No recording in progress.');
      return;
    }
    this.http.post(`${this.apiUrl}/stop-recording`, { archiveId: this.archiveId }).subscribe((res: any) => {
      alert('Recording stopped.');
      this.archiveId = null;
    });
  }
  
}
