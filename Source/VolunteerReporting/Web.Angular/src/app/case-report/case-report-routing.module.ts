import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';

import {CaseReportListComponent} from './case-report-list/case-report-list.component';

/*import { environment } from './environment';
console.log('PRODUCTION:',environment.production);*/

const routes: Routes = [
  {
    path: 'case-report',
    children: [
      {
        path: '',
        redirectTo: 'list',
        pathMatch: 'full'
      },
      {
        path: 'list',
        component: CaseReportListComponent
      }
    ]
  }
];

export const CaseReportRouting = RouterModule.forChild(routes);
