import drinkStore from './drinks/internalStore';
import appetizerStore from './appetizer/internalStore';
import dessertStore from './dessert/internalStore';
import mainCourseStore from './mainCourse/internalStore';


export default {
    namespaced: true,
    modules: {
        drinkStore, appetizerStore, dessertStore, mainCourseStore
    }
};




