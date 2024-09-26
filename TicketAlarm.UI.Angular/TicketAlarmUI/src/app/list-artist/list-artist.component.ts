import { Component } from '@angular/core';
import  { ShowService, ArtistService }  from '../../client/api/api'
import  { ShowDto }  from '../../client/model/showDto'
import  { ArtistDto }  from '../../client/model/artistDto'
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { NgxMasonryModule } from 'ngx-masonry';
import { BestShowsComponent } from './../best-shows/best-shows.component';

@Component({
  selector: 'app-list-artist',
  standalone: true,
  imports: [CommonModule, NgxMasonryModule, BestShowsComponent],
  templateUrl: './list-artist.component.html',
  styleUrl: './list-artist.component.css'
})

export class ListArtistComponent {
    public listShow: ShowDto[] | undefined;
    public listArtist: ArtistDto[] | undefined;
    constructor(private route: ActivatedRoute, private showService: ShowService, private artistService: ArtistService, private router: Router) {}
  
    ngOnInit(): void {
      this.showService.apiShowsGet(true, true).subscribe(res => this.listShow = res);
      this.artistService.apiArtistsGet().subscribe(res => this.listArtist = res);
    }

    public navigateToPage(id : number = 0): void{
      this.router.navigate(["show", id]);
    }

    public isPlural(artist : ArtistDto){
      return artist.shows && artist.shows.length > 1;
    }
}
