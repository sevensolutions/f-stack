const notifications = reactive<IScheduledNotification[]>([]);

let notificationIndex = 0;

export interface INotification {
  icon: string;
  iconColor: string;
  title: string;
  message: string;
  buttons?: INotificationButton[];
  timeout?: number;
}

export interface INotificationButton {
  title: string;
  action: () => void;
}

interface IScheduledNotification extends INotification {
  id: number;
  close: () => void;
  timeoutHandle?: NodeJS.Timeout;
}

export function useNotifications() {
  function showMessage(notification: INotification) {
    const scheduled: IScheduledNotification = {
      id: notificationIndex++,
      close: () => remove(scheduled),
      ...notification
    };

    // Wrap all actions, so that we always close the notification first
    if (scheduled.buttons) {
      for(let b of scheduled.buttons) {
        const origAction = b.action;
        b.action = () => {
          remove(scheduled);
          origAction();
        };
      }
    }

    notifications.push(scheduled);

    if (notification.timeout)
      scheduled.timeoutHandle = setTimeout(() => remove(scheduled), notification.timeout);
  }

  function showInfo(title: string, message: string, timeout?: number) {
    showMessage({
      icon: "fa-check",
      iconColor: "text-green-400",
      title: title,
      message: message,
      timeout: timeout || 3000
    });
  }

  function showError(ex: any) {
    let text = "";

    if (ex instanceof Error) {
      text = ex.message;
      if (ex.cause)
        text += "\n" + ex.cause;
    }
    else
      text = ex as string;

    showMessage({
      icon: "fa-triangle-exclamation",
      iconColor: "text-red-400",
      title: "Error",
      message: text,
      timeout: 10000,
      // buttons: [
      //   {
      //     title: "Details",
      //     action: () => {}
      //   }
      // ]
    });
  }

  function remove(notification: IScheduledNotification) {
    if (notification.timeoutHandle)
      clearTimeout(notification.timeoutHandle);

    const index = notifications.indexOf(notification);
    notifications.splice(index, 1);
  }

  return { notifications, showMessage, showInfo, showError };
}
