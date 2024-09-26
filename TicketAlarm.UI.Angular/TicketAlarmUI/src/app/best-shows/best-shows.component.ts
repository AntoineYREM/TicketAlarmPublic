import { Component } from '@angular/core';
import { ShowDto }  from '../../client/model/showDto'
import { ShowService }  from '../../client/api/api'
import { Router } from '@angular/router';

import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-best-shows',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './best-shows.component.html',
  styleUrl: './best-shows.component.css'
})
export class BestShowsComponent {
  public listShow: ShowDto[] | undefined;

  constructor(private showService: ShowService, private router: Router) {}
        

  ngOnInit(): void {
    this.showService.apiShowsGet(true, true).subscribe(res => this.listShow = res);
  }

  public navigateToPage(id : number = 0): void{
    this.router.navigate(["show", id]);
  }
}
