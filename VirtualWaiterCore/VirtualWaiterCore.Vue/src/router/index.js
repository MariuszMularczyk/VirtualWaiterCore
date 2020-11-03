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
    {
        path: '/administration/dessertsList',
        name: 'administration.dessertsList',
        component: () => import('@/views/administration/dessert/views/Index')
    },    
    {
        path: '/administration/dessert/add',
        name: 'administration.dessert.add',
        component: () => import('@/views/administration/dessert/views/Add')
        },  
    {
        path: '/administration/dessert/edit/:id',
        name: 'administration.dessert.edit',
        component: () => import('@/views/administration/dessert/views/Edit')
    }, 
    {
        path: '/administration/appetizersList',
        name: 'administration.appetizersList',
        component: () => import('@/views/administration/appetizer/views/Index')
    },    
    {
        path: '/administration/appetizer/add',
        name: 'administration.appetizer.add',
        component: () => import('@/views/administration/appetizer/views/Add')
        },  
    {
        path: '/administration/appetizer/edit/:id',
        name: 'administration.appetizer.edit',
        component: () => import('@/views/administration/appetizer/views/Edit')
    },
    {
        path: '/administration/mainCoursesList',
        name: 'administration.mainCoursesList',
        component: () => import('@/views/administration/mainCourse/views/Index')
    },    
    {
        path: '/administration/mainCourse/add',
        name: 'administration.mainCourse.add',
        component: () => import('@/views/administration/mainCourse/views/Add')
    },  
    {
        path: '/administration/mainCourse/edit/:id',
        name: 'administration.mainCourse.edit',
        component: () => import('@/views/administration/mainCourse/views/Edit')
    },
    {
        path: '/order/menu',
        name: 'order.menu',
        component: () => import('@/views/order/order/views/Index')
    },
    {
        path: '/order/setTable',
        name: 'order.setTable',
        component: () => import('@/views/order/order/views/SetTable')
    },
  ]
});
