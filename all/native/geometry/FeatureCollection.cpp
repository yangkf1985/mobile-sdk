#include "FeatureCollection.h"
#include "components/Exceptions.h"

namespace carto {

    FeatureCollection::FeatureCollection(std::vector<std::shared_ptr<Feature> > features) :
        _features(std::move(features))
    {
    }

    FeatureCollection::~FeatureCollection() {
    }

    int FeatureCollection::getFeatureCount() const {
        return static_cast<int>(_features.size());
    }
    
    std::shared_ptr<Feature> FeatureCollection::getFeature(int index) const {
        if (index < 0 || index >= static_cast<int>(_features.size())) {
            throw OutOfRangeException("Feature index out of range");
        }
        return _features[index];
    }

}
