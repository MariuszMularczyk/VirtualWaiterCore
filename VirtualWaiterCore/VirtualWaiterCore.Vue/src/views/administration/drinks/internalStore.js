import indexStore from './storeModules/index';
import addStore from './storeModules/add';
import editStore from './storeModules/edit';

export default {
    namespaced: true,
    modules: {
        indexStore, addStore, editStore
    }
};




