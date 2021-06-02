import { http } from '../http/index'
import { ApiGateway } from '../gateways/api'
import { AppGateway } from '../gateways/app'
import { ModuleGateway } from '../gateways/module'
import { ParameterGateway } from '../gateways/parameter'
import { ProjectGateway } from '../gateways/project'
import { ProxyGateway } from '../gateways/proxy'
import { VersionGateway } from '../gateways/version'

export const apiGateway = new ApiGateway(http)
export const appGateway = new AppGateway(http)
export const moduleGateway = new ModuleGateway(http)
export const parameterGateway = new ParameterGateway(http)
export const projectGateway = new ProjectGateway(http)
export const proxyGateway = new ProxyGateway(http)
export const versionGateway = new VersionGateway(http)