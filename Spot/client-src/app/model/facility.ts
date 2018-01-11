import {Stat} from './stat';

export interface Faciltiy {
    id: string;
    code: number;
    name: string;
    emr: string;
    project: string;
    created: Date;
    stats: Stat;
}
