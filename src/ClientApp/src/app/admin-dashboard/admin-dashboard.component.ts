import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css']
})
export class AdminDashboardComponent implements OnInit {

  adminData: string;
  constructor(private userService: UserService) { }

  ngOnInit(): void {
  }
  fetchAdminData() {
    this.userService.testAdmin().subscribe((result: string) => {
      this.adminData = result;
    });
  }

}
