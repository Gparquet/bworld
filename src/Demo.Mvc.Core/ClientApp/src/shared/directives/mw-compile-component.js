﻿import app from '../../app.module';
const name = 'mw-compile';

app.directive(name, [
  '$compile',
  function($compile) {
    return function(scope, element, attrs) {
      scope.$watch(
        function(scope) {
          // watch the 'compile' expression for changes
          return scope.$eval(attrs.compile);
        },
        function(value) {
          // when the 'compile' expression changes
          // assign it into the current DOM
          element.html(value);

          // compile the new DOM and link it to the current
          // scope.
          // NOTE: we only compile .childNodes so that
          // we don't get into infinite loop compiling ourselves
          $compile(element.contents())(scope);
        }
      );
    };
  },
]);

export default name;
