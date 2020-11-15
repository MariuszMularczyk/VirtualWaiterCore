import orderStore from './order/internalStore';
import kitchenStore from './kitchen/internalStore';



export default {
    namespaced: true,
    modules: {
        orderStore, kitchenStore
    }
};




