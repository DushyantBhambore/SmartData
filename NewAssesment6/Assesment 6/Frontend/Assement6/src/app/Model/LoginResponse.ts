export interface LoginResponse {
    token: string;
    message: string;
    data: string; // Role or other string data
    logindata:any;
  }