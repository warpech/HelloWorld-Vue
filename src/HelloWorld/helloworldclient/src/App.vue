<template>
  <HelloWorld v-model="obj" />
  <!-- v-model directive has special meaning in Vue. It creates 2-way data binding. See: https://vuejs.org/v2/guide/components.html#Using-v-model-on-Components -->
</template>

<script>
import { PalindromDOM } from 'palindrom'
import HelloWorld from './components/HelloWorld.vue'
function connectToPalindrom(onConnect) { // copied from https://github.com/Palindrom/palindrom.github.io/blob/source/public/lab/vue/src/App.vue
  new PalindromDOM({
    remoteUrl: "/HelloWorld",
    onStateReset: onConnect,
    debug: false,
    localVersionPath: "/_ver#c$",
    remoteVersionPath: "/_ver#s",
    ot: true,
    useWebSocket: true
  });
}
export default {
  name: 'app',
  components: {
    HelloWorld
  },
  methods: {
    onConnect(obj) {
      // use Palindrom's data object in the "App" component's data
      // eslint-disable-next-line
      console.log("connected", obj);
      this.obj = obj;
    }
  },
  created() {
    // when an instance of the "App" component is created, request Palindrom connection and provide a callback
    connectToPalindrom(this.onConnect);
  },
  data: function() {
    return {
      obj: null
    };
  }
}
</script>