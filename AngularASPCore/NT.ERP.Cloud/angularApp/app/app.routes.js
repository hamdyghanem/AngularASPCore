import { RouterModule } from '@angular/router';
export var routes = [
    { path: '', redirectTo: 'default', pathMatch: 'full' },
    {
        path: 'about', loadChildren: './about/about.module#AboutModule',
    }
];
export var AppRoutes = RouterModule.forRoot(routes);
//# sourceMappingURL=app.routes.js.map