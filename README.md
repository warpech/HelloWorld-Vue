# Create a Real Time UI with Starcounter and Vue

### Introduction
By default, Starcounter uses Polymer and WebComponents. In this project, we will rely on Vue to handle user interaction.
### Before You Start
This project is a recreation of the complete Starcounter Hello World Tutorial (https://docs.starcounter.io/hello-world-tutorial)

### So how does this work?

#### 1. Set up the Vue project

I have used Vue CLI, a tool explained here: https://cli.vuejs.org/guide/installation.html

I have started with an existing C# project of Starcounter app.

By convention, I want `wwwroot/helloworldclient` to contain the built client-side files. So let's go to the directory that contains `HelloWorld.csproj` and create another subdirectory `helloworldclient` for the Vue project source files:

```
vue create helloworldclient
```

For all the questions asked by the CLI tool, press ENTER to accept the defaults.

Configure the Vue builder to respect our source and output directory preference:

```js
// HelloWorld/helloworldclient/vue.config.js
module.exports = {
   publicPath: '/helloworldclient',
   outputDir: "../wwwroot/helloworldclient"
}
```

If all goes well, running `npm run build` in `helloworldclient` should populate the folder `wwwroot/helloworldclient`.

![screenshot](docs/01-npm-run-build.png)