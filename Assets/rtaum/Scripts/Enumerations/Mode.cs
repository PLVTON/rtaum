/*
    Oldest: This prioritize the older data and will ignore new values if the queue is full.
    Latest: This prioritize the newest data and will erase older values when the queue is full.
    Hybrid: This prioritize average data, it alternates between the two modes.
    Random: This throws a random value from the queue out in order to drop the latest data?
*/

namespace rtaum.Enumeration {
    public enum Mode {
        Oldest,
        Latest,
        Hybrid,
        Random
    }
}
