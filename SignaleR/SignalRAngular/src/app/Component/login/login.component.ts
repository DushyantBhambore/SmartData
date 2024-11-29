import { Component, inject, OnInit } from '@angular/core';
import { IUserDto } from '../Model/UserDto';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoginService } from '../../Service/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {

  userform : FormGroup = new FormGroup({})

  service = inject(LoginService)
  router = inject(Router)
  constructor(private fb : FormBuilder) { }
  ngOnInit(): void {
    this.setForm();
  }

  setForm()
  {
    this.userform = this.fb.group({
      email: ['' , [Validators.required, Validators.email]],
      password: ['',[Validators.required]]
    })
  }
  onSubmit()
  {
    this.service.onlogin(this.userform.value)

  }
}
