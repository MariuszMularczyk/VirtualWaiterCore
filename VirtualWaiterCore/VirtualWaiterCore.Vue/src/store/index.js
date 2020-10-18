import Vue from 'vue';
import Vuex from 'vuex';
import administrationStore from '../views/administration/administrationStore';


Vue.use(Vuex);

export default new Vuex.Store({
    namespaced: true,
    modules: {
        administrationStore
  }
});
