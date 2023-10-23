export interface IClientConfig {
    typesense?: ITypesenseClientConfig;
  }
  
  export interface ITypesenseClientConfig {
    isEnabled: boolean;
    host: string;
    path?: string;
    port: number;
    protocol: string;
    apiKey: string;
  }
  
  export interface IUserInfo {
    fullName: string;
    initials: string;
    email: string;
    profileImage?: string;
  }
  
  export interface IUserNotificationPreview {
    id: number;
    createDate: string;
    createBy: IUserInfo;
    title: string;
    subject?: string;
  }
  