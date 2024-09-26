import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import { AlarmDto, AlarmService,ShowService,ShowDto  } from '../../client';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, FormsModule, Validators, AbstractControl }    from '@angular/forms';


@Component({
  selector: 'app-create-alarm',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule ],
  templateUrl: './create-alarm.component.html',
  styleUrl: './create-alarm.component.css'
})
export class CreateAlarmComponent implements OnInit {
  private sub: any;
  public id: number = 0;
  public show: ShowDto = {};
  public alarmForm!: FormGroup;
  public formBuilder!: FormBuilder;

  constructor(private route: ActivatedRoute,private router: Router,private showService: ShowService, private fb: FormBuilder, private alarmService: AlarmService) {
    this.formBuilder = fb;
    this.createAlarmForm();
  }

  ngOnInit(): void {

    this.sub = this.route.params.subscribe(params => {
      
      this.id = +params['id']; 
      this.showService.apiShowsIdShowGet(this.id).subscribe(res => this.show = res);
   });
  }

  createAlarmForm() {
    this.alarmForm = this.formBuilder.group({
      email: ['', {updateOn: 'submit', validators : [Validators.required, Validators.minLength(7), Validators.pattern('^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,4}$') ]} ],
    });
  }

  onSubmit() {
    this.alarmForm.markAllAsTouched();
    if(this.alarmForm.valid){
      this.alarmService.apiAlarmsPost( { idShow : this.id,  mail : this.alarmForm.controls['email'].value }).subscribe();
      this.router.navigate(["confirmation"])
    }
  }

}
