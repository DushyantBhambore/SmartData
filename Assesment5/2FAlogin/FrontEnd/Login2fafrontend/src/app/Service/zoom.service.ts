import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ZoomService {
  private zoomApiUrl = 'https://localhost:7276/api/Zoom/GenerateToken';
  private token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJKd3QgVG9rZW5zIFN1YmplY3QiLCJVc2VySWQiOiIxIiwiRW1haWwiOiJyZWRvdzM5NDU2QGdpYW5lcy5jb20iLCJleHAiOjE3MzE4MzYzNjYsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTE0NiIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTE0NiJ9.MyocBnGiBLtFJQvsSfNJlyLCM9zJ4hH8UlReSZwnrl0'; // Replace with your JWT token

  constructor(private http: HttpClient) {}

  // Create a Zoom meeting
  createMeeting(): Observable<any> {
    const headers = new HttpHeaders().set('Authorization', `Bearer ${this.token}`);
    const meetingData = {
      topic: 'Test Meeting',
      type: 2, // Scheduled meeting
      start_time: new Date().toISOString(), // Set the start time for the meeting
      duration: 30, // Duration in minutes
      timezone: 'UTC',
      agenda: 'Test Agenda',
    };

    return this.http.post(this.zoomApiUrl, meetingData, { headers });
  }

  // Get meeting details by meeting ID
  getMeetingDetails(meetingId: string): Observable<any> {
    const headers = new HttpHeaders().set('Authorization', `Bearer ${this.token}`);
    return this.http.get(`${this.zoomApiUrl}/meetings/${meetingId}`, { headers });
  }

  // Generate a Zoom join URL
  generateJoinUrl(meetingId: string): string {
    return `https://zoom.us/j/${meetingId}`;
  }

}
