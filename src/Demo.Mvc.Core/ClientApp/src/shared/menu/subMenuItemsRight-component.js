﻿import { menu } from './menu-factory';

import SocialMenuItemRight from '../../social/socialMenuItemRight-component';
import FreeMenuItemRight from '../../free/freeMenuItemRight-component';

import React from 'react';

const ChildItem = props => {
  const { menuItem, index, currentPath } = props;
  let Item = null;
  const isActive = menu.isActive(menuItem.routePath, currentPath);
  const className = isActive ? 'active' : '';
  switch (menuItem.module) {
    case 'Social':
      Item = (
        <SocialMenuItemRight menuItem={menuItem} currentPath={currentPath} />
      );
      break;
    default:
      Item = (
        <FreeMenuItemRight menuItem={menuItem} currentPath={currentPath} />
      );
      break;
  }

  return <li className={className}>{Item}</li>;
};

export default class SubMenuItemsRight extends React.Component {
  constructor(props) {
    super(props);
  }
  render() {
    const { menuItems, currentPath, isVisible } = this.props;
    if (!isVisible) {
      return null;
    }
    const listItems = menuItems.map((child, index) => (
      <ChildItem
        menuItem={child}
        index={index}
        key={child.moduleId}
        currentPath={currentPath}
      />
    ));
    return <React.Fragment>{listItems} </React.Fragment>;
  }
}

SubMenuItemsRight.defaultProps = {
  isVisible: true,
};
