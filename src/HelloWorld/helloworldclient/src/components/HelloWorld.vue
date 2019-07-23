<template>
  <div class="hello" v-if="value">
    <h1>{{value.FullName}}'s expense list</h1>

    <fieldset>
        <label>First name:</label>
        <input v-model="value.FirstName$">
    </fieldset>

    <fieldset>
        <label>Last name:</label>
        <input v-model="value.LastName$">
    </fieldset>

    <button v-on:click="value.SaveTrigger$ += 1">Save</button>
    <button v-on:click="value.CancelTrigger$ += 1">Cancel</button>

    <hr>

    <div v-for="(item,i) in value.Expenses" v-bind:key="item.ObjectId">
      <Expense v-model="value.Expenses[i]" />
      <!-- note: this might be naive, see https://forum.vuejs.org/t/how-to-use-v-model-inside-the-v-for-loop-in-order-to-access-a-current-object/7764/5 -->
    </div>

    <button v-on:click="value.NewExpenseTrigger$ += 1">Add new expense</button>

    <hr>

    <h2>Current Balance: {{value.CurrentBalance}}</h2>
    <button v-on:click="value.DeleteAllTrigger$ += 1">Delete all expenses</button>
  </div>
</template>

<script>
import Expense from './Expense.vue'

export default {
  name: 'HelloWorld',
  props: {
    value: Object // the name of the prop must be "value" to work with v-model in the parent component
  },
  components: {
    Expense
  },
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
