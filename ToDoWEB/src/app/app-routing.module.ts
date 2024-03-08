import { NgModule } from '@angular/core';
import { RouterModule, Routes} from '@angular/router';
import { MainLayout } from '@shared/layouts/main/main.layout';

const routes: Routes = [
  {
    path: '',
    component: MainLayout,
    children: [
      {
        path: '',
        loadChildren: () => import('@users/users.module').then(m => m.UsersModule)
      },
      {
        path: ':id/tasks',
        loadChildren: () => import('@tasks/tasks.module').then(m => m.TasksModule)
      }

    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    scrollPositionRestoration: 'enabled'
  })],
  exports: [RouterModule],
  
})
export class AppRoutingModule { }
