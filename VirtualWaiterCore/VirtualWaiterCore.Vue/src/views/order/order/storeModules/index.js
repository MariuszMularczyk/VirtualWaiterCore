import axios from 'axios';
import { getField, updateField } from 'vuex-map-fields';
const namespaced = true;

const state = {
    appetizersList: null,
    dessertList: null,
    drinksList: null,
    mainCoursesList: null,
    Order: {
        Table: null,
        ProductOrders: [],
    },
   
    cartItems: [],
};

const getters = {
    getField,
  getAppetizersList(state) {
    return state.appetizersList;
  },
  getMainCoursesList(state) {
    return state.mainCoursesList;
  },
  getDrinksList(state) {
    return state.drinksList;
  },
  getDessertsList(state) {
    return state.dessertList;
  },
  cartItems(state) {
    return state.cartItems;
    },
  cartTotal(state) {
    return state.cartItems.reduce((total, item) => total + item.product.price * item.quantity, 0.0);
  },
};

const mutations = {
    updateField,
  setAppetizersList(state, payload) {
        state.appetizersList = payload;
  },
  addProductToCart(state, product) {
      const cartItem = state.cartItems.reduce((item, cartItem) => cartItem.product === product ? cartItem : item, null);

      if (!cartItem) {
          state.cartItems = [...state.cartItems, { quantity: 1, product }];
      } else {
          cartItem.quantity++;
      }
    },
  addProductIdToCart(state, productId) {
      const cartItem = state.Order.ProductOrders.reduce((item, cartItem) => cartItem.productId === productId ? cartItem : item, null);
      console.log(cartItem)

    if (!cartItem) {
        state.Order.ProductOrders = [...state.Order.ProductOrders, { quantity: 1, productId }];
    } else {
       cartItem.quantity++;
    }
      console.log(state.Order)
  },
  setDessertsList(state, payload) {
        state.dessertList = payload;
  },
  setDrinksList(state, payload) {
        state.drinksList = payload;
  },
  setMainCoursesList(state, payload) {
        state.mainCoursesList = payload;
    },

  cancelOrder(state) {
     state.cartItems = [];
     state.Order.ProductOrders = [];
  },
  removeProduct(state, item) {
     state.cartItems = state.cartItems.filter(cartItem => cartItem !== item);
    },
  removeProductId(state, item) {
      state.Order.ProductOrders = state.Order.ProductOrders.filter(cartItem => cartItem !== item);
    },
  reduceQuantity(state, product) {
        const cartItem = state.Order.ProductOrders.reduce((item, cartItem) => cartItem.product === product ? cartItem : item, null);
        cartItem.quantity--;
  },
  addQuantity(state, product) {
        const cartItem = state.Order.ProductOrders.reduce((item, cartItem) => cartItem.product === product ? cartItem : item, null);
        cartItem.quantity++;
  },
};

const actions = {
    setAppetizersList({commit}) {
        axios.get('/appetizer/getAppetizers')
            .then(({ data }) => commit('setAppetizersList', data));
    },
    setDessertsList({ commit }) {
        axios.get('/dessert/getDesserts')
            .then(({ data }) => commit('setDessertsList', data));
    },
    setDrinksList({ commit }) {
        axios.get('/drink/getDrinks')
            .then(({ data }) => commit('setDrinksList', data));
    },
    setMainCoursesList({ commit }) {
        axios.get('/mainCourse/getMainCourses')
            .then(({ data }) => commit('setMainCoursesList', data));
    },
    addToCart({ commit }, product) {
        commit('addProductToCart', product)
        commit('addProductIdToCart', product.id)
    },
    cancelOrder({ commit }) {
        commit('cancelOrder')
    },
    removeProduct({ commit }, product) {
        commit('removeProduct', product)
        commit('removeProductId', product.id)
    },
    reduceQuantity ({ commit }, product) {
        commit('reduceQuantity', product)
    },
    addQuantity({ commit }, product) {
        commit('addQuantity', product)
    },
    addOrder({ state } ) {
        axios.post('/order/add', state.Order);
    },
};

export default {namespaced, state, getters, mutations, actions };




