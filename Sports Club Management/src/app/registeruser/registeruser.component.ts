import { Component, OnInit } from '@angular/core';
import { ProfileService } from 'app/services/profile.service';
import { NgForm } from '@angular/forms'
 import { ToastrService } from 'ngx-toastr';
 import { Router } from '@angular/router';
import { AuthService } from 'app/services/auth.service';
import { Profile } from 'app/models/profile.model';


@Component({
  selector: 'app-registeruser',
  templateUrl: './registeruser.component.html',
  styleUrls: ['./registeruser.component.css']
})
export class RegisteruserComponent implements OnInit {
 
  profileList: Profile[];

  constructor(private profileService: ProfileService,private tostr: ToastrService,private authService: AuthService, private router: Router) { }

  ngOnInit() {
    var x = this.profileService.getData();
    x.snapshotChanges().subscribe(item => {
      this.profileList = [];
      item.forEach(element => {
        var y = element.payload.toJSON();
        y["$key"] = element.key;
        this.profileList.push(y as Profile);
      });
    });
  }

  onSubmit(profileForm: NgForm) {
    if (profileForm.value.uid == null)
    {
      this.authService.createUserWithEmail(this.profileService.selectedProfile.email, this.profileService.selectedProfile.password)
        .then((res) => {
          alert('New user '+res.email+' created successfully');
          console.log(profileForm.value.name);
          console.log(res.email);
         //alert(res);
        
        this.router.navigate(['/']);
        })
        .catch((err) => { 
          alert(err);
          console.log('error: ' + err);
        });
        this.profileService.insertProfile(profileForm.value); 
    }
   
    else
      this.profileService.updateProfile(profileForm.value);
      this.resetForm(profileForm);
      this.tostr.success('Submitted Succcessfully', 'Profile Register');
  }
 
  resetForm(profileForm?: NgForm) {
    if (profileForm != null)
    profileForm.reset();
    this.profileService.selectedProfile = {
      $key: null,
      email: '',
      password: '',
      name: '',
      dob:'',
      gender:'',
      
    }
  }

  returnHome(){
    this.router.navigate(['./']);
  }
 

}
