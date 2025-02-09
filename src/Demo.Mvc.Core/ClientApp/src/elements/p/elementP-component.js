﻿import app from '../../app.module';
import React from 'react';
import ReactDOM from 'react-dom';
import { react2angular } from 'react2angular';

export const Paragraphe = ({element}) => {
    return (
      <div
        id={element.property}
        dangerouslySetInnerHTML={{ __html: element.data }}
      />
    );
};

const name = 'elementP';
app.component(name, react2angular(Paragraphe, ['element']));

export default name;
