import { Component, inject, OnInit } from '@angular/core';
import { RegisterComponent } from '../register/register.component';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RegisterComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent implements OnInit {
  ngOnInit(): void {
    this.getUsers();
  }
  http = inject(HttpClient);
  registerMode = false;
  users: any;

  registerToggle() {
    this.registerMode = !this.registerMode;
  }

  getUsers() {
    this.http.get<any[]>('http://localhost:5000/api/users').subscribe({
      next: (users) => (this.users = users),
      error: (err) => console.error('Failed to load users', err),
      complete: () => console.log('Request has completed', this.users),
    });
  }
}
