import { Component } from '@angular/core';
import { ZoomService } from '../../Service/zoom.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-zoom',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './zoom.component.html',
  styleUrl: './zoom.component.css'
})
export class ZoomComponent {
  meetingId: string = '';
  joinUrl: string = '';
  isMeetingCreated: boolean = false;

  constructor(private zoomService: ZoomService) {}

  ngOnInit(): void {}
  
  // Create a Zoom meeting

  createMeeting(): void {
    debugger
    this.zoomService.createMeeting().subscribe(
      (response) => {
        this.meetingId = response.id;
        this.joinUrl = this.zoomService.generateJoinUrl(this.meetingId);
        this.isMeetingCreated = true;
        console.log('Meeting created:', response);
      },
      (error) => {
        console.error('Error creating meeting:', error);
      }
    );
  }

  // Join the meeting
  joinMeeting(): void {
    window.open(this.joinUrl, '_blank');
  }


}
