window.onload = function() {
  //<editor-fold desc="Changeable Configuration Block">

  // the following lines will be replaced by docker/configurator, when it runs in a docker-container
  // window.ui = SwaggerUIBundle({
  //   url: "https://petstore.swagger.io/v2/swagger.json",
  //   dom_id: '#swagger-ui',
  //   deepLinking: true,
  //   presets: [
  //     SwaggerUIBundle.presets.apis,
  //     SwaggerUIStandalonePreset
  //   ],
  //   plugins: [
  //     SwaggerUIBundle.plugins.DownloadUrl 
  //   ],
  //   layout: "StandaloneLayout"
  // });
  //
  // window.onload = function() {
  //   // Build a system
  //   const ui = SwaggerUIBundle({
  //     url: document.location.origin + "/swagger/docs/v1",  // API 목록 조회 URL
  //     // url: "http://localhost:5000/" + "/swagger/docs/v1",  // API 목록 조회 URL
  //     dom_id: '#swagger-ui',
  //     presets: [
  //       SwaggerUIBundle.presets.apis,
  //       SwaggerUIStandalonePreset
  //     ],
  //     plugins: [
  //       SwaggerUIBundle.plugins.DownloadUrl
  //     ],
  //     layout: "StandaloneLayout"
  //   })
  //
  //   window.ui = ui
  // }
  

  window.ui = SwaggerUIBundle({
    url: document.location.origin + "/swagger/docs/v1",  // API 목록 조회 URL
    dom_id: '#swagger-ui',
    deepLinking: true,
    presets: [
      SwaggerUIBundle.presets.apis,
      SwaggerUIStandalonePreset
    ],
    plugins: [
      SwaggerUIBundle.plugins.DownloadUrl 
    ],
    layout: "StandaloneLayout"
  });


  //</editor-fold>
};
