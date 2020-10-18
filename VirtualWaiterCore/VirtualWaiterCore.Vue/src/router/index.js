import Vue from 'vue';
import Router from 'vue-router';

Vue.use(Router);

export default new Router({
    routes: [
/*    {
        path: '',
        name: 'menu',
        component: () => import('@/views/Menu')
    },*/
    {
        path: '/administrationDashboard',
        name: 'administrationDashboard',
        component: () => import('@/views/administration/administrationDashboard/AdministrationDashboard')
    },
    {
        path: '/administration/drinksList',
        name: 'administration.drinksList',
        component: () => import('@/views/administration/drinks/views/DrinksList')
    },    
    {
        path: '/administration/drink/add',
        name: 'administration.drink.add',
        component: () => import('@/views/administration/drinks/views/Add')
        },  
    {
        path: '/administration/drink/edit/:id',
        name: 'administration.drink.edit',
        component: () => import('@/views/administration/drinks/views/Edit')
    }, 
  ]
});
