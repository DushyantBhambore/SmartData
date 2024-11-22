import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-video-call',
  standalone: true,
  imports: [],
  templateUrl: './video-call.component.html',
  styleUrl: './video-call.component.css'
})
export class VideoCallComponent {
  apiKey = 'b669c86a';
  sessionId: string = '';
  token: string = '';
  session: OT.Session | null = null;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    // Fetch sessionId and token
    this.http.get('http://localhost:5000/api/video/create-session').subscribe((res: any) => {
      this.sessionId = res.sessionId;

      this.http
        .get(`http://localhost:5000/api/video/generate-token?sessionId=${this.sessionId}`)
        .subscribe((res: any) => {
          this.token = res.token;
          this.initializeSession();
        });
    });
  }

  initializeSession() {
    this.session = OT.initSession(this.apiKey, this.sessionId);

    this.session.on('streamCreated', (event) => {
      this.session?.subscribe(event.stream, 'subscriber', {
        insertMode: 'append',
        width: '100%',
        height: '100%',
      });
    });

    this.session.connect(this.token, (err) => {
      if (err) {
        console.error('Failed to connect', err);
      } else {
        const publisher = OT.initPublisher('publisher', {
          insertMode: 'append',
          width: '100%',
          height: '100%',
        });
        this.session?.publish(publisher);
      }
    });
  }

  // startScreenSharing() {
  //   OT.checkScreenSharingCapability((response) => {
  //     if (!response.supported || !response.extensionRegistered) {
  //       alert('Screen sharing not supported or extension not registered');
  //       return;
  //     }

  //     OT.initPublisher(
  //       'publisher',
  //       {
  //         videoSource: 'screen',
  //       },
  //       (err, publisher) => {
  //         if (err) {
  //           console.error(err);
  //         } else {
  //           this.session?.publish(publisher);
  //         }
  //       }
  //     );
  //   });
  // }




  startRecording() {
    this.http.post(`http://localhost:5000/api/video/start-recording?sessionId=${this.sessionId}`, {}).subscribe((res: any) => {
      alert('Recording started. Archive ID: ' + res.archiveId);
    });
  }



  stopRecording(archiveId: string) {
    this.http.post(`http://localhost:5000/api/video/stop-recording?archiveId=${archiveId}`, {}).subscribe(() => {
      alert('Recording stopped');
    });
  }

  

}
