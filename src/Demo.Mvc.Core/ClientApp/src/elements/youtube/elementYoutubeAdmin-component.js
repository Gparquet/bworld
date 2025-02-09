﻿import app from '../../app.module';
import { service as elementService } from '../element-factory';
import view from './youtube_admin.html';

const name = 'elementYoutubeAdmin';

function ElementController() {
  var ctrl = this;
  elementService.inherit(ctrl);
  return ctrl;
}

app.component(name, {
  template: view,
  controller: [ElementController],
  bindings: {
    element: '=',
    onChange: '<',
  },
});

export default name;
