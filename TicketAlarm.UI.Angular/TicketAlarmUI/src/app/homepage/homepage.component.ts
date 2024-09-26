import { Component } from '@angular/core';
import { BestShowsComponent } from './../best-shows/best-shows.component';
import { HomepageInfoComponent } from '../homepage-info/homepage-info.component';
import { HomepageHeaderComponent } from '../homepage-header/homepage-header.component';
import { ListArtistComponent } from '../list-artist/list-artist.component';

@Component({
  selector: 'app-homepage',
  standalone: true,
  imports: [BestShowsComponent, HomepageInfoComponent, HomepageHeaderComponent, ListArtistComponent],
  templateUrl: './homepage.component.html',
  styleUrl: './homepage.component.css'
})
export class HomepageComponent {

}
