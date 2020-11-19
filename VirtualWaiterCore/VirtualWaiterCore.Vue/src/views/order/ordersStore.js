import orderStore from './order/internalStore';
import kitchenStore from './kitchen/internalStore';
import barStore from './bar/internalStore';



export default {
    namespaced: true,
    modules: {
        orderStore, kitchenStore, barStore
    }
};




