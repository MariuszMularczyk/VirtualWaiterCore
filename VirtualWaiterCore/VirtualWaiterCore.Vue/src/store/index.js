import Vue from 'vue';
import Vuex from 'vuex';
import administrationStore from '../views/administration/administrationStore';
import ordersStore from '../views/order/ordersStore';


Vue.use(Vuex);

export default new Vuex.Store({
    namespaced: true,
    modules: {
        administrationStore, ordersStore
  }
});
