import { Routes } from '@angular/router';
import { ListArtistComponent } from './list-artist/list-artist.component';
import { CreateAlarmComponent } from './create-alarm/create-alarm.component';
import { ConfirmationAlarmComponent } from './confirmation-alarm/confirmation-alarm.component';
import { HomepageComponent } from './homepage/homepage.component';
import { CgvComponent } from './cgv/cgv.component';
import { CookieInformationComponent } from './cookie-information/cookie-information.component';


export const routes: Routes = [
    { path: '', component: HomepageComponent },
    { path: 'show/:id', component: CreateAlarmComponent },
    { path: 'confirmation', component: ConfirmationAlarmComponent },
    { path: 'cookie', component: CookieInformationComponent },
    { path: 'conditions-generales', component: CgvComponent },
    { path: '**', component: HomepageComponent }
];
