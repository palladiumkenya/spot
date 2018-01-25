import {Stat} from './stat';
import {Info} from './info';

export interface Faciltiy {
    id: string;
    code: number;
    name: string;
    emr: string;
    project: string;
    created: Date;
    stats: Stat;
    info?: Info;
}
