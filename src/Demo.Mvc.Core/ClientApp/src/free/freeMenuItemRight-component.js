﻿import { getIcon } from '../shared/icons';

import React from 'react';
import ReactDOM from 'react-dom';
import { react2angular } from 'react2angular';
import NewsMenuItem from '../news/newsMenuItem-component';
import { SubChildItem } from '../news/newsMenuItem-component';
import SubMenuItemsRight from '../shared/menu/subMenuItemsRight-component';
import PropTypes from 'prop-types';

export const SubMenu = ({ menuItems, className, currentPath }) => {
  if (!menuItems || menuItems.length < 0) {
    return null;
  }

  return (
    <ul className={className}>
      <SubMenuItemsRight
        start={0}
        end={100}
        menuItems={menuItems}
        currentPath={currentPath}
      />
    </ul>
  );
};

SubMenu.defaultProps = {
  className: 'mw-submenu',
};

const FreeMenuItemRight = ({ menuItem, currentPath }) => {
  const childs = menuItem.childs;
  if (!childs || childs.length <= 0) {
    return <NewsMenuItem menuItem={menuItem} currentPath={currentPath} />;
  }

  return (
      <React.Fragment>
        <a href={menuItem.routePath}>
          <span className={getIcon(menuItem)} />
          <span> {menuItem.title}</span>
          <b className="caret" />
        </a>
        <SubMenu menuItem={menuItem.childs} currentPath={currentPath} />
      </React.Fragment>
  );
};

export default FreeMenuItemRight
