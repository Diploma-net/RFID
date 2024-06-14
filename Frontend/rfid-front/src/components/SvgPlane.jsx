import { statusColors } from "../const/colors"
import { planePlaces } from "../const/plane"
import { memo, useMemo } from 'react';

export const SvgPlane = memo(({ placeStatuses }) => {
    if (placeStatuses === undefined || placeStatuses.size === 0) {
        return;
    }
    const places = useMemo(() => {
        const places = [];
        for (let p of placeStatuses) {
            const placeId = p[0];
            const status = p[1];
            if (placeId === undefined || status === undefined) {
                continue;
            } 
            const place = planePlaces.find((place) => place.id === placeId);
            places.push(
                <rect
                    key={placeId}
                    id={placeId}
                    x={place.x}
                    y={place.y}
                    width={place.width}
                    height={place.height}
                    rx="6"
                    ry="6"
                    clipPath
                    fill={statusColors[status] || statusColors[1]}
                />
            );
        }
        return places;
    }, [placeStatuses]);

    return (
        <svg viewBox="0 0 1565 425" width="1565px" height="425px" xmlns="http://www.w3.org/2000/svg">
            <g xmlns="http://www.w3.org/2000/svg" transform="matrix(0 -1 1 0 -0 425)">
                <g id="base_plane">
                    <g id="plane_bgr_1_">
                        <g>
                            <defs>
                                <polygon id="SVGID_1_" points="120.2,1479.6 304.1,1483.7 304.1,-3.6 120.2,-7.8 &#9;&#9;&#9;&#9;" />
                            </defs>
                            <defs>
                                <polygon id="SVGID_2_" points="120.2,-7.8 304.2,-3.6 304.2,1483.8 120.2,1479.6 &#9;&#9;&#9;&#9;" />
                            </defs>
                        </g>
                        <g>
                            <defs>
                                <polygon id="SVGID_5_" points="120.2,1479.6 304.1,1483.7 304.1,-3.6 120.2,-7.8 &#9;&#9;&#9;&#9;" />
                            </defs>
                            <defs>
                                <polygon id="SVGID_6_" points="120.2,-7.8 304.2,-3.6 304.2,1483.8 120.2,1479.6 &#9;&#9;&#9;&#9;" />
                            </defs>
                        </g>
                        <g>
                            <defs>
                                <polygon id="SVGID_9_" points="120.2,1479.6 304.1,1483.7 304.1,-3.6 120.2,-7.8 &#9;&#9;&#9;&#9;" />
                            </defs>
                            <defs>
                                <path id="SVGID_10_" d="M131.5,214.1C161.3,109.4,196,32.4,212.4,32.4c16.2,0,50.4,78.5,80.9,181.7l0,0c1,4,1.6,8.1,1.6,12.3 v981.1l0,0c0,4.1-0.5,8.1-1.5,12.1c-39.9,156.9-66.9,246.6-81,246.6c-14,0-41-89.7-81-246.6l0,0c-1-4-1.5-8-1.5-12.1V226.4l0,0 C129.9,222.2,130.4,218.1,131.5,214.1L131.5,214.1z" />
                            </defs>
                            <defs>
                                <polygon id="SVGID_11_" points="120.2,-7.8 304.2,-3.6 304.2,1483.8 120.2,1479.6 &#9;&#9;&#9;&#9;" />
                            </defs>
                            <clipPath id="SVGID_12_">
                                <polygon points="120.2,1479.6 304.1,1483.7 304.1,-3.6 120.2,-7.8 &#9;&#9;&#9;&#9;" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_13_" clipPath="url(#SVGID_12_)">
                                <path d="M131.5,214.1C161.3,109.4,196,32.4,212.4,32.4c16.2,0,50.4,78.5,80.9,181.7l0,0c1,4,1.6,8.1,1.6,12.3 v981.1l0,0c0,4.1-0.5,8.1-1.5,12.1c-39.9,156.9-66.9,246.6-81,246.6c-14,0-41-89.7-81-246.6l0,0c-1-4-1.5-8-1.5-12.1V226.4l0,0 C129.9,222.2,130.4,218.1,131.5,214.1L131.5,214.1z" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_14_" clipPath="url(#SVGID_13_)">
                                <polygon points="120.2,-7.8 304.2,-3.6 304.2,1483.8 120.2,1479.6 &#9;&#9;&#9;&#9;" overflow="visible" />
                            </clipPath>
                            <rect x="127.5" y="-6.1" clipPath="url(#SVGID_14_)" fill="#F3F3F3" width="169.9" height="1484.2" style={{ paintOrder: "fill" }} />
                        </g>
                        <g>
                            <defs>
                                <polygon id="SVGID_15_" points="120.2,1477.4 304.1,1481.5 304.8,-5.9 120.9,-10 &#9;&#9;&#9;&#9;" />
                            </defs>
                            <defs>
                                <path id="SVGID_16_" d="M133.9,234.6L133.9,234.6v959.3c23,113.3,49.2,149.2,78.5,149.2c29.4,0,55.6-35.9,78.5-149.2V234.5 c0,0,0-15.2-4.2-26c0,0-19.2-8-75.2-8c0,0-61.6,1.1-74.1,9C137.3,209.5,132.7,226.4,133.9,234.6z" />
                            </defs>
                            <clipPath id="SVGID_17_">
                                <polygon points="120.2,1477.4 304.1,1481.5 304.8,-5.9 120.9,-10 &#9;&#9;&#9;&#9;" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_18_" clipPath="url(#SVGID_17_)">
                                <path d="M133.9,234.6L133.9,234.6v959.3c23,113.3,49.2,149.2,78.5,149.2c29.4,0,55.6-35.9,78.5-149.2V234.5 c0,0,0-15.2-4.2-26c0,0-19.2-8-75.2-8c0,0-61.6,1.1-74.1,9C137.3,209.5,132.7,226.4,133.9,234.6z" overflow="visible" />
                            </clipPath>
                            <rect x="132.6" y="118.5" clipPath="url(#SVGID_18_)" fill="#FFFFFF" width="162" height="1247.7" style={{ paintOrder: "fill" }} />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_19_" x="120.2" y="-7.5" width="184" height="1487.4" />
                            </defs>
                        </g>
                        <g />
                    </g>
                    <path id="nose_mobile" fill-rule="evenodd" clip-rule="evenodd" fill="#FFFFFF" d="M137.8,209.5c0,0,19.2-91.8,74.8-90.3 c0,0,52.9-5.2,74.5,89.3" style={{ paintOrder: "fill" }} />
                    <g id="wings_back">
                        <path fill="#F3F3F3" d="M121.9,1365l21.3-17.5l15.5-28.3c0,0,20.3,78.3,37.4,121.5c0,0-15.7,2.2-23.7,6.4l-50.4,23.4V1365z" style={{ paintOrder: "fill" }} />
                        <path fill="#F3F3F3" d="M303.1,1365l-21.3-17.5l-15.5-28.3c0,0-20.2,77.6-37.4,121.5c0,0,15.7,2.2,23.7,6.4l50.4,23.4V1365z" style={{ paintOrder: "fill" }} />
                    </g>
                    <g>
                        <g id="wings_4_">
                            <polygon fill="#E5E5E5" points="131.7,516.9 10.9,560.5 10.9,904.1 131.7,868.2 &#9;&#9;&#9;" style={{ paintOrder: "fill" }} />
                        </g>
                        <g id="wings_2_">
                            <polygon fill="#E5E5E5" points="293.3,516.9 414.1,560.5 414.1,904.1 293.3,868.2 &#9;&#9;&#9;" style={{ paintOrder: "fill" }} />
                        </g>
                    </g>
                </g>
                <g id="rooms">
                    <g>
                        <defs>
                            <path id="SVGID_21_" d="M197.5,121.1v40c0,0.6-0.5,1.1-1.1,1.1h-41.6C154.7,162.2,171,128.2,197.5,121.1z" />
                        </defs>
                        <path d="M197.5,121.1v40c0,0.6-0.5,1.1-1.1,1.1h-41.6C154.7,162.2,171,128.2,197.5,121.1z" overflow="visible" fill-rule="evenodd" clip-rule="evenodd" fill="#2DB4D0" />
                    </g>
                    <g>
                        <defs>
                            <path id="SVGID_23_" d="M224.3,162.2c-0.6,0-1.1-0.5-1.1-1.1l0-40.7c20.9,5.6,36,21.7,46.9,41.8H224.3z" />
                        </defs>
                        <path d="M224.3,162.2c-0.6,0-1.1-0.5-1.1-1.1l0-40.7c20.9,5.6,36,21.7,46.9,41.8H224.3z" overflow="visible" fill-rule="evenodd" clip-rule="evenodd" fill="#2DB4D0" />
                    </g>
                    <g>
                        <g>
                            <defs>
                                <rect id="SVGID_25_" x="232.9" y="143.1" width="13.2" height="7.7" />
                            </defs>
                            <defs>
                                <path id="SVGID_26_" d="M239,150.8c3.4,0,6.1-0.3,6.1-0.6c0-0.4-2.7-0.6-6.1-0.6c-3.4,0-6.1,0.3-6.1,0.6 C232.9,150.5,235.7,150.8,239,150.8L239,150.8z" />
                            </defs>
                            <clipPath id="SVGID_27_">
                                <rect x="232.9" y="143.1" width="13.2" height="7.7" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_28_" clipPath="url(#SVGID_27_)">
                                <path d="M239,150.8c3.4,0,6.1-0.3,6.1-0.6c0-0.4-2.7-0.6-6.1-0.6c-3.4,0-6.1,0.3-6.1,0.6 C232.9,150.5,235.7,150.8,239,150.8L239,150.8z" overflow="visible" />
                            </clipPath>
                            <rect x="231.3" y="147.9" clipPath="url(#SVGID_28_)" fill="#FFFFFF" width="15.4" height="4.5" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_29_" x="232.9" y="143.1" width="13.2" height="7.7" />
                            </defs>
                            <defs>
                                <path id="SVGID_30_" d="M235.1,143.1h7.8l0,0c0.2,0,0.3,0.1,0.3,0.3c0.3,1.4,0.4,2.6,0.3,3.6c-0.1,1-0.6,2.1-1.5,3.1l0,0 c-0.1,0.1-0.1,0.1-0.2,0.1h-5.5l0,0c-0.1,0-0.2,0-0.2-0.1c-0.9-0.9-1.4-1.9-1.5-3.1c-0.1-1.2,0-2.4,0.3-3.6l0,0 C234.8,143.2,235,143.1,235.1,143.1L235.1,143.1z" />
                            </defs>
                            <clipPath id="SVGID_31_">
                                <rect x="232.9" y="143.1" width="13.2" height="7.7" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_32_" clipPath="url(#SVGID_31_)">
                                <path d="M235.1,143.1h7.8l0,0c0.2,0,0.3,0.1,0.3,0.3c0.3,1.4,0.4,2.6,0.3,3.6c-0.1,1-0.6,2.1-1.5,3.1l0,0 c-0.1,0.1-0.1,0.1-0.2,0.1h-5.5l0,0c-0.1,0-0.2,0-0.2-0.1c-0.9-0.9-1.4-1.9-1.5-3.1c-0.1-1.2,0-2.4,0.3-3.6l0,0 C234.8,143.2,235,143.1,235.1,143.1L235.1,143.1z" overflow="visible" />
                            </clipPath>
                            <rect x="232.9" y="141.5" clipPath="url(#SVGID_32_)" fill="#FFFFFF" width="12.3" height="10.3" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_33_" x="232.9" y="143.1" width="13.2" height="7.7" />
                            </defs>
                            <clipPath id="SVGID_34_">
                                <rect x="232.9" y="143.1" width="13.2" height="7.7" overflow="visible" />
                            </clipPath>
                            <path clipPath="url(#SVGID_34_)" fill="#FFFFFF" d="M244.2,148.5c-1.1,0-1.9-0.9-1.9-1.9c0-1.1,0.9-1.9,1.9-1.9 c1.1,0,1.9,0.9,1.9,1.9C246.1,147.7,245.2,148.5,244.2,148.5z M244.2,145.3c-0.7,0-1.3,0.6-1.3,1.3c0,0.7,0.6,1.3,1.3,1.3 c0.7,0,1.3-0.6,1.3-1.3C245.5,145.9,244.9,145.3,244.2,145.3z" />
                        </g>
                    </g>
                    <g>
                        <g>
                            <defs>
                                <rect id="SVGID_35_" x="175.1" y="139.7" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_36_" d="M177,142.8L177,142.8L177,142.8c0.2,0.1,0.4,0.4,0.3,0.6l-1.2,3.2l0,0c-0.1,0.2-0.3,0.4-0.6,0.3l0,0l0,0 c-0.2-0.1-0.4-0.3-0.3-0.6l1.2-3.2l0,0C176.5,142.8,176.8,142.7,177,142.8L177,142.8z" />
                            </defs>
                            <clipPath id="SVGID_37_">
                                <rect x="175.1" y="139.7" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_38_" clipPath="url(#SVGID_37_)">
                                <path d="M177,142.8L177,142.8L177,142.8c0.2,0.1,0.4,0.4,0.3,0.6l-1.2,3.2l0,0c-0.1,0.2-0.3,0.4-0.6,0.3l0,0l0,0 c-0.2-0.1-0.4-0.3-0.3-0.6l1.2-3.2l0,0C176.5,142.8,176.8,142.7,177,142.8L177,142.8z" overflow="visible" />
                            </clipPath>
                            <rect x="172" y="142.3" transform="matrix(0.3419 -0.9397 0.9397 0.3419 -20.089 260.9215)" clipPath="url(#SVGID_38_)" fill="#FFFFFF" width="8.5" height="5.1" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_39_" x="175.1" y="139.7" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_40_" d="M177.5,148.8L177.5,148.8L177.5,148.8c0.3,0,0.6,0.3,0.6,0.6v3.9l0,0c0,0.3-0.3,0.6-0.6,0.6l0,0l0,0 c-0.3,0-0.6-0.3-0.6-0.6v-3.9l0,0C176.9,149.1,177.2,148.8,177.5,148.8L177.5,148.8z" />
                            </defs>
                            <clipPath id="SVGID_41_">
                                <rect x="175.1" y="139.7" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_42_" clipPath="url(#SVGID_41_)">
                                <path d="M177.5,148.8L177.5,148.8L177.5,148.8c0.3,0,0.6,0.3,0.6,0.6v3.9l0,0c0,0.3-0.3,0.6-0.6,0.6l0,0l0,0 c-0.3,0-0.6-0.3-0.6-0.6v-3.9l0,0C176.9,149.1,177.2,148.8,177.5,148.8L177.5,148.8z" overflow="visible" />
                            </clipPath>
                            <rect x="174.8" y="146.8" clipPath="url(#SVGID_42_)" fill="#FFFFFF" width="5.3" height="9.2" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_43_" x="175.1" y="139.7" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_44_" d="M179.1,148.8L179.1,148.8L179.1,148.8c0.3,0,0.6,0.3,0.6,0.6v3.9l0,0c0,0.3-0.3,0.6-0.6,0.6l0,0l0,0 c-0.3,0-0.6-0.3-0.6-0.6v-3.9l0,0C178.5,149.1,178.8,148.8,179.1,148.8L179.1,148.8z" />
                            </defs>
                            <clipPath id="SVGID_45_">
                                <rect x="175.1" y="139.7" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_46_" clipPath="url(#SVGID_45_)">
                                <path d="M179.1,148.8L179.1,148.8L179.1,148.8c0.3,0,0.6,0.3,0.6,0.6v3.9l0,0c0,0.3-0.3,0.6-0.6,0.6l0,0l0,0 c-0.3,0-0.6-0.3-0.6-0.6v-3.9l0,0C178.5,149.1,178.8,148.8,179.1,148.8L179.1,148.8z" overflow="visible" />
                            </clipPath>
                            <rect x="176.4" y="146.8" clipPath="url(#SVGID_46_)" fill="#FFFFFF" width="5.3" height="9.2" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_47_" x="175.1" y="139.7" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_48_" d="M179.6,142.8L179.6,142.8L179.6,142.8c0.2-0.1,0.5,0,0.6,0.3l1.2,3.2l0,0c0.1,0.2,0,0.5-0.3,0.6l0,0l0,0 c-0.2,0.1-0.5,0-0.6-0.3l-1.2-3.2l0,0C179.3,143.1,179.4,142.8,179.6,142.8L179.6,142.8z" />
                            </defs>
                            <clipPath id="SVGID_49_">
                                <rect x="175.1" y="139.7" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_50_" clipPath="url(#SVGID_49_)">
                                <path d="M179.6,142.8L179.6,142.8L179.6,142.8c0.2-0.1,0.5,0,0.6,0.3l1.2,3.2l0,0c0.1,0.2,0,0.5-0.3,0.6l0,0l0,0 c-0.2,0.1-0.5,0-0.6-0.3l-1.2-3.2l0,0C179.3,143.1,179.4,142.8,179.6,142.8L179.6,142.8z" overflow="visible" />
                            </clipPath>
                            <rect x="177.8" y="140.5" transform="matrix(0.9398 -0.3418 0.3418 0.9398 -38.6324 70.3805)" clipPath="url(#SVGID_50_)" fill="#FFFFFF" width="5.1" height="8.5" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_51_" x="175.1" y="139.7" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_52_" d="M176.9,142.6h2.7l0,0c0.2,0,0.4,0.2,0.4,0.4c0,0,0,0,0,0.1l-0.4,3.2h-2.8l-0.4-3.2l0,0 C176.5,142.9,176.6,142.7,176.9,142.6C176.9,142.6,176.9,142.6,176.9,142.6L176.9,142.6z" />
                            </defs>
                            <clipPath id="SVGID_53_">
                                <rect x="175.1" y="139.7" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_54_" clipPath="url(#SVGID_53_)">
                                <path d="M176.9,142.6h2.7l0,0c0.2,0,0.4,0.2,0.4,0.4c0,0,0,0,0,0.1l-0.4,3.2h-2.8l-0.4-3.2l0,0 C176.5,142.9,176.6,142.7,176.9,142.6C176.9,142.6,176.9,142.6,176.9,142.6L176.9,142.6z" overflow="visible" />
                            </clipPath>
                            <rect x="174.4" y="140.6" clipPath="url(#SVGID_54_)" fill="#FFFFFF" width="7.7" height="7.8" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_55_" x="175.1" y="139.7" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_56_" d="M176.5,149.3h3.5l0,0c0.2,0,0.4-0.2,0.4-0.4c0,0,0-0.1,0-0.1l-0.8-3.2h-2.8l-0.8,3.2l0,0 C176.1,149,176.2,149.2,176.5,149.3C176.4,149.3,176.5,149.3,176.5,149.3L176.5,149.3z" />
                            </defs>
                            <clipPath id="SVGID_57_">
                                <rect x="175.1" y="139.7" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_58_" clipPath="url(#SVGID_57_)">
                                <path d="M176.5,149.3h3.5l0,0c0.2,0,0.4-0.2,0.4-0.4c0,0,0-0.1,0-0.1l-0.8-3.2h-2.8l-0.8,3.2l0,0 C176.1,149,176.2,149.2,176.5,149.3C176.4,149.3,176.5,149.3,176.5,149.3L176.5,149.3z" overflow="visible" />
                            </clipPath>
                            <rect x="174" y="143.5" clipPath="url(#SVGID_58_)" fill="#FFFFFF" width="8.5" height="7.8" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_59_" x="175.1" y="139.7" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_60_" d="M178.4,142.2c0.7,0,1.3-0.6,1.3-1.3c0-0.7-0.6-1.3-1.3-1.3c-0.7,0-1.3,0.6-1.3,1.3 C177.1,141.6,177.7,142.2,178.4,142.2L178.4,142.2z" />
                            </defs>
                            <clipPath id="SVGID_61_">
                                <rect x="175.1" y="139.7" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_62_" clipPath="url(#SVGID_61_)">
                                <path d="M178.4,142.2c0.7,0,1.3-0.6,1.3-1.3c0-0.7-0.6-1.3-1.3-1.3c-0.7,0-1.3,0.6-1.3,1.3 C177.1,141.6,177.7,142.2,178.4,142.2L178.4,142.2z" overflow="visible" />
                            </clipPath>
                            <rect x="175.1" y="137.6" clipPath="url(#SVGID_62_)" fill="#FFFFFF" width="6.7" height="6.7" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_63_" x="175.1" y="139.7" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_64_" d="M186.6,142.8L186.6,142.8L186.6,142.8c0.2,0.1,0.4,0.4,0.3,0.6l-1.2,3.2l0,0c-0.1,0.2-0.3,0.4-0.6,0.3 l0,0l0,0c-0.2-0.1-0.4-0.3-0.3-0.6l1.2-3.2l0,0C186.1,142.8,186.4,142.7,186.6,142.8L186.6,142.8z" />
                            </defs>
                            <clipPath id="SVGID_65_">
                                <rect x="175.1" y="139.7" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_66_" clipPath="url(#SVGID_65_)">
                                <path d="M186.6,142.8L186.6,142.8L186.6,142.8c0.2,0.1,0.4,0.4,0.3,0.6l-1.2,3.2l0,0c-0.1,0.2-0.3,0.4-0.6,0.3 l0,0l0,0c-0.2-0.1-0.4-0.3-0.3-0.6l1.2-3.2l0,0C186.1,142.8,186.4,142.7,186.6,142.8L186.6,142.8z" overflow="visible" />
                            </clipPath>
                            <rect x="181.6" y="142.3" transform="matrix(0.3418 -0.9398 0.9398 0.3418 -13.7309 270.0039)" clipPath="url(#SVGID_66_)" fill="#FFFFFF" width="8.5" height="5.1" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_67_" x="175.1" y="139.7" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_68_" d="M187.1,146.5L187.1,146.5L187.1,146.5c0.3,0,0.6,0.3,0.6,0.6v6.2l0,0c0,0.3-0.3,0.6-0.6,0.6l0,0l0,0 c-0.3,0-0.6-0.3-0.6-0.6v-6.2l0,0C186.5,146.8,186.8,146.5,187.1,146.5L187.1,146.5z" />
                            </defs>
                            <clipPath id="SVGID_69_">
                                <rect x="175.1" y="139.7" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_70_" clipPath="url(#SVGID_69_)">
                                <path d="M187.1,146.5L187.1,146.5L187.1,146.5c0.3,0,0.6,0.3,0.6,0.6v6.2l0,0c0,0.3-0.3,0.6-0.6,0.6l0,0l0,0 c-0.3,0-0.6-0.3-0.6-0.6v-6.2l0,0C186.5,146.8,186.8,146.5,187.1,146.5L187.1,146.5z" overflow="visible" />
                            </clipPath>
                            <rect x="184.5" y="144.5" clipPath="url(#SVGID_70_)" fill="#FFFFFF" width="5.3" height="11.5" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_71_" x="175.1" y="139.7" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_72_" d="M188.7,146.5L188.7,146.5L188.7,146.5c0.3,0,0.6,0.3,0.6,0.6v6.2l0,0c0,0.3-0.3,0.6-0.6,0.6l0,0l0,0 c-0.3,0-0.6-0.3-0.6-0.6v-6.2l0,0C188.1,146.8,188.4,146.5,188.7,146.5L188.7,146.5z" />
                            </defs>
                            <clipPath id="SVGID_73_">
                                <rect x="175.1" y="139.7" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_74_" clipPath="url(#SVGID_73_)">
                                <path d="M188.7,146.5L188.7,146.5L188.7,146.5c0.3,0,0.6,0.3,0.6,0.6v6.2l0,0c0,0.3-0.3,0.6-0.6,0.6l0,0l0,0 c-0.3,0-0.6-0.3-0.6-0.6v-6.2l0,0C188.1,146.8,188.4,146.5,188.7,146.5L188.7,146.5z" overflow="visible" />
                            </clipPath>
                            <rect x="186.1" y="144.5" clipPath="url(#SVGID_74_)" fill="#FFFFFF" width="5.3" height="11.5" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_75_" x="175.1" y="139.7" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_76_" d="M189.3,142.8L189.3,142.8L189.3,142.8c0.2-0.1,0.5,0,0.6,0.3l1.2,3.2l0,0c0.1,0.2,0,0.5-0.3,0.6l0,0l0,0 c-0.2,0.1-0.5,0-0.6-0.3l-1.2-3.2l0,0C188.9,143.1,189,142.8,189.3,142.8L189.3,142.8z" />
                            </defs>
                            <clipPath id="SVGID_77_">
                                <rect x="175.1" y="139.7" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_78_" clipPath="url(#SVGID_77_)">
                                <path d="M189.3,142.8L189.3,142.8L189.3,142.8c0.2-0.1,0.5,0,0.6,0.3l1.2,3.2l0,0c0.1,0.2,0,0.5-0.3,0.6l0,0l0,0 c-0.2,0.1-0.5,0-0.6-0.3l-1.2-3.2l0,0C188.9,143.1,189,142.8,189.3,142.8L189.3,142.8z" overflow="visible" />
                            </clipPath>
                            <rect x="187.5" y="140.5" transform="matrix(0.9398 -0.3418 0.3418 0.9398 -38.0532 73.6767)" clipPath="url(#SVGID_78_)" fill="#FFFFFF" width="5.1" height="8.5" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_79_" x="175.1" y="139.7" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_80_" d="M186.5,142.6h2.8l0,0c0.2,0,0.4,0.2,0.4,0.4c0,0,0,0,0,0l-0.2,4.7l0,0c0,0.2-0.2,0.4-0.4,0.4h-2.4l0,0 c-0.2,0-0.4-0.2-0.4-0.4l-0.2-4.7l0,0C186.1,142.8,186.3,142.6,186.5,142.6C186.5,142.6,186.5,142.6,186.5,142.6L186.5,142.6z" />
                            </defs>
                            <clipPath id="SVGID_81_">
                                <rect x="175.1" y="139.7" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_82_" clipPath="url(#SVGID_81_)">
                                <path d="M186.5,142.6h2.8l0,0c0.2,0,0.4,0.2,0.4,0.4c0,0,0,0,0,0l-0.2,4.7l0,0c0,0.2-0.2,0.4-0.4,0.4h-2.4l0,0 c-0.2,0-0.4-0.2-0.4-0.4l-0.2-4.7l0,0C186.1,142.8,186.3,142.6,186.5,142.6C186.5,142.6,186.5,142.6,186.5,142.6L186.5,142.6z" overflow="visible" />
                            </clipPath>
                            <rect x="184" y="140.6" clipPath="url(#SVGID_82_)" fill="#FFFFFF" width="7.8" height="9.7" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_83_" x="175.1" y="139.7" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_84_" d="M188,142.2c0.7,0,1.3-0.6,1.3-1.3c0-0.7-0.6-1.3-1.3-1.3c-0.7,0-1.3,0.6-1.3,1.3 C186.8,141.6,187.3,142.2,188,142.2L188,142.2z" />
                            </defs>
                            <clipPath id="SVGID_85_">
                                <rect x="175.1" y="139.7" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_86_" clipPath="url(#SVGID_85_)">
                                <path d="M188,142.2c0.7,0,1.3-0.6,1.3-1.3c0-0.7-0.6-1.3-1.3-1.3c-0.7,0-1.3,0.6-1.3,1.3 C186.8,141.6,187.3,142.2,188,142.2L188,142.2z" overflow="visible" />
                            </clipPath>
                            <rect x="184.7" y="137.6" clipPath="url(#SVGID_86_)" fill="#FFFFFF" width="6.7" height="6.7" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_87_" x="182.9" y="139.7" width="0.7" height="14.4" />
                            </defs>
                            <clipPath id="SVGID_88_">
                                <rect x="182.9" y="139.7" width="0.7" height="14.4" overflow="visible" />
                            </clipPath>
                            <rect x="180.8" y="137.6" clipPath="url(#SVGID_88_)" fill="#FFFFFF" width="4.8" height="18.6" />
                        </g>
                    </g>
                    <g>
                        <defs>
                            <path id="SVGID_89_" d="M228,1173.8h62.3c0.5,0,0.9,0.4,0.9,0.9l-0.3,20.8l-2.2,9.9c0,0.5-0.4,0.9-0.9,0.9H228 c-0.5,0-0.9-0.4-0.9-0.9v-30.7C227.1,1174.2,227.5,1173.8,228,1173.8L228,1173.8z" />
                        </defs>
                        <path d="M228,1173.8h62.3c0.5,0,0.9,0.4,0.9,0.9l-0.3,20.8l-2.2,9.9c0,0.5-0.4,0.9-0.9,0.9H228 c-0.5,0-0.9-0.4-0.9-0.9v-30.7C227.1,1174.2,227.5,1173.8,228,1173.8L228,1173.8z" overflow="visible" fill-rule="evenodd" clip-rule="evenodd" fill="#2DB4D0" />
                    </g>
                    <g>
                        <g>
                            <defs>
                                <rect id="SVGID_91_" x="251" y="1182.8" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_92_" d="M252.9,1185.9L252.9,1185.9L252.9,1185.9c0.2,0.1,0.4,0.4,0.3,0.6l-1.2,3.2l0,0 c-0.1,0.2-0.3,0.4-0.6,0.3l0,0l0,0c-0.2-0.1-0.4-0.3-0.3-0.6l1.2-3.2l0,0C252.4,1185.9,252.7,1185.8,252.9,1185.9L252.9,1185.9z " />
                            </defs>
                            <clipPath id="SVGID_93_">
                                <rect x="251" y="1182.8" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_94_" clipPath="url(#SVGID_93_)">
                                <path d="M252.9,1185.9L252.9,1185.9L252.9,1185.9c0.2,0.1,0.4,0.4,0.3,0.6l-1.2,3.2l0,0 c-0.1,0.2-0.3,0.4-0.6,0.3l0,0l0,0c-0.2-0.1-0.4-0.3-0.3-0.6l1.2-3.2l0,0C252.4,1185.9,252.7,1185.8,252.9,1185.9L252.9,1185.9z " overflow="visible" />
                            </clipPath>
                            <rect x="247.9" y="1185.4" transform="matrix(0.3419 -0.9397 0.9397 0.3419 -950.3733 1018.7343)" clipPath="url(#SVGID_94_)" fill="#FFFFFF" width="8.5" height="5.1" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_95_" x="251" y="1182.8" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_96_" d="M253.4,1191.9L253.4,1191.9L253.4,1191.9c0.3,0,0.6,0.3,0.6,0.6v3.9l0,0c0,0.3-0.3,0.6-0.6,0.6l0,0l0,0 c-0.3,0-0.6-0.3-0.6-0.6v-3.9l0,0C252.8,1192.2,253.1,1191.9,253.4,1191.9L253.4,1191.9z" />
                            </defs>
                            <clipPath id="SVGID_97_">
                                <rect x="251" y="1182.8" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_98_" clipPath="url(#SVGID_97_)">
                                <path d="M253.4,1191.9L253.4,1191.9L253.4,1191.9c0.3,0,0.6,0.3,0.6,0.6v3.9l0,0c0,0.3-0.3,0.6-0.6,0.6l0,0l0,0 c-0.3,0-0.6-0.3-0.6-0.6v-3.9l0,0C252.8,1192.2,253.1,1191.9,253.4,1191.9L253.4,1191.9z" overflow="visible" />
                            </clipPath>
                            <rect x="250.8" y="1189.9" clipPath="url(#SVGID_98_)" fill="#FFFFFF" width="5.3" height="9.2" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_99_" x="251" y="1182.8" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_100_" d="M255,1191.9L255,1191.9L255,1191.9c0.3,0,0.6,0.3,0.6,0.6v3.9l0,0c0,0.3-0.3,0.6-0.6,0.6l0,0l0,0 c-0.3,0-0.6-0.3-0.6-0.6v-3.9l0,0C254.4,1192.2,254.7,1191.9,255,1191.9L255,1191.9z" />
                            </defs>
                            <clipPath id="SVGID_101_">
                                <rect x="251" y="1182.8" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_102_" clipPath="url(#SVGID_101_)">
                                <path d="M255,1191.9L255,1191.9L255,1191.9c0.3,0,0.6,0.3,0.6,0.6v3.9l0,0c0,0.3-0.3,0.6-0.6,0.6l0,0l0,0 c-0.3,0-0.6-0.3-0.6-0.6v-3.9l0,0C254.4,1192.2,254.7,1191.9,255,1191.9L255,1191.9z" overflow="visible" />
                            </clipPath>
                            <rect x="252.4" y="1189.9" clipPath="url(#SVGID_102_)" fill="#FFFFFF" width="5.3" height="9.2" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_103_" x="251" y="1182.8" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_104_" d="M255.6,1185.9L255.6,1185.9L255.6,1185.9c0.2-0.1,0.5,0,0.6,0.3l1.2,3.2l0,0c0.1,0.2,0,0.5-0.3,0.6l0,0 l0,0c-0.2,0.1-0.5,0-0.6-0.3l-1.2-3.2l0,0C255.2,1186.2,255.3,1186,255.6,1185.9L255.6,1185.9z" />
                            </defs>
                            <clipPath id="SVGID_105_">
                                <rect x="251" y="1182.8" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_106_" clipPath="url(#SVGID_105_)">
                                <path d="M255.6,1185.9L255.6,1185.9L255.6,1185.9c0.2-0.1,0.5,0,0.6,0.3l1.2,3.2l0,0c0.1,0.2,0,0.5-0.3,0.6l0,0 l0,0c-0.2,0.1-0.5,0-0.6-0.3l-1.2-3.2l0,0C255.2,1186.2,255.3,1186,255.6,1185.9L255.6,1185.9z" overflow="visible" />
                            </clipPath>
                            <rect x="253.8" y="1183.7" transform="matrix(0.9398 -0.3418 0.3418 0.9398 -390.623 159.1679)" clipPath="url(#SVGID_106_)" fill="#FFFFFF" width="5.1" height="8.5" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_107_" x="251" y="1182.8" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_108_" d="M252.8,1185.8h2.7l0,0c0.2,0,0.4,0.2,0.4,0.4c0,0,0,0,0,0.1l-0.4,3.2h-2.8l-0.4-3.2l0,0 C252.4,1186,252.6,1185.8,252.8,1185.8C252.8,1185.8,252.8,1185.8,252.8,1185.8L252.8,1185.8z" />
                            </defs>
                            <clipPath id="SVGID_109_">
                                <rect x="251" y="1182.8" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_110_" clipPath="url(#SVGID_109_)">
                                <path d="M252.8,1185.8h2.7l0,0c0.2,0,0.4,0.2,0.4,0.4c0,0,0,0,0,0.1l-0.4,3.2h-2.8l-0.4-3.2l0,0 C252.4,1186,252.6,1185.8,252.8,1185.8C252.8,1185.8,252.8,1185.8,252.8,1185.8L252.8,1185.8z" overflow="visible" />
                            </clipPath>
                            <rect x="250.3" y="1183.7" clipPath="url(#SVGID_110_)" fill="#FFFFFF" width="7.7" height="7.8" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_111_" x="251" y="1182.8" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_112_" d="M252.4,1192.4h3.5l0,0c0.2,0,0.4-0.2,0.4-0.4c0,0,0-0.1,0-0.1l-0.8-3.2h-2.8l-0.8,3.2l0,0 C252,1192.1,252.1,1192.3,252.4,1192.4C252.4,1192.4,252.4,1192.4,252.4,1192.4L252.4,1192.4z" />
                            </defs>
                            <clipPath id="SVGID_113_">
                                <rect x="251" y="1182.8" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_114_" clipPath="url(#SVGID_113_)">
                                <path d="M252.4,1192.4h3.5l0,0c0.2,0,0.4-0.2,0.4-0.4c0,0,0-0.1,0-0.1l-0.8-3.2h-2.8l-0.8,3.2l0,0 C252,1192.1,252.1,1192.3,252.4,1192.4C252.4,1192.4,252.4,1192.4,252.4,1192.4L252.4,1192.4z" overflow="visible" />
                            </clipPath>
                            <rect x="250" y="1186.7" clipPath="url(#SVGID_114_)" fill="#FFFFFF" width="8.5" height="7.8" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_115_" x="251" y="1182.8" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_116_" d="M254.3,1185.3c0.7,0,1.3-0.6,1.3-1.3c0-0.7-0.6-1.3-1.3-1.3c-0.7,0-1.3,0.6-1.3,1.3 C253.1,1184.7,253.6,1185.3,254.3,1185.3L254.3,1185.3z" />
                            </defs>
                            <clipPath id="SVGID_117_">
                                <rect x="251" y="1182.8" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_118_" clipPath="url(#SVGID_117_)">
                                <path d="M254.3,1185.3c0.7,0,1.3-0.6,1.3-1.3c0-0.7-0.6-1.3-1.3-1.3c-0.7,0-1.3,0.6-1.3,1.3 C253.1,1184.7,253.6,1185.3,254.3,1185.3L254.3,1185.3z" overflow="visible" />
                            </clipPath>
                            <rect x="251" y="1180.7" clipPath="url(#SVGID_118_)" fill="#FFFFFF" width="6.7" height="6.7" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_119_" x="251" y="1182.8" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_120_" d="M262.6,1185.9L262.6,1185.9L262.6,1185.9c0.2,0.1,0.4,0.4,0.3,0.6l-1.2,3.2l0,0 c-0.1,0.2-0.3,0.4-0.6,0.3l0,0l0,0c-0.2-0.1-0.4-0.3-0.3-0.6l1.2-3.2l0,0C262.1,1185.9,262.3,1185.8,262.6,1185.9L262.6,1185.9z " />
                            </defs>
                            <clipPath id="SVGID_121_">
                                <rect x="251" y="1182.8" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_122_" clipPath="url(#SVGID_121_)">
                                <path d="M262.6,1185.9L262.6,1185.9L262.6,1185.9c0.2,0.1,0.4,0.4,0.3,0.6l-1.2,3.2l0,0 c-0.1,0.2-0.3,0.4-0.6,0.3l0,0l0,0c-0.2-0.1-0.4-0.3-0.3-0.6l1.2-3.2l0,0C262.1,1185.9,262.3,1185.8,262.6,1185.9L262.6,1185.9z " overflow="visible" />
                            </clipPath>
                            <rect x="257.6" y="1185.4" transform="matrix(0.3418 -0.9398 0.9398 0.3418 -944.0582 1027.9686)" clipPath="url(#SVGID_122_)" fill="#FFFFFF" width="8.5" height="5.1" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_123_" x="251" y="1182.8" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_124_" d="M263,1189.7L263,1189.7L263,1189.7c0.3,0,0.6,0.3,0.6,0.6v6.2l0,0c0,0.3-0.3,0.6-0.6,0.6l0,0l0,0 c-0.3,0-0.6-0.3-0.6-0.6v-6.2l0,0C262.5,1189.9,262.7,1189.7,263,1189.7L263,1189.7z" />
                            </defs>
                            <clipPath id="SVGID_125_">
                                <rect x="251" y="1182.8" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_126_" clipPath="url(#SVGID_125_)">
                                <path d="M263,1189.7L263,1189.7L263,1189.7c0.3,0,0.6,0.3,0.6,0.6v6.2l0,0c0,0.3-0.3,0.6-0.6,0.6l0,0l0,0 c-0.3,0-0.6-0.3-0.6-0.6v-6.2l0,0C262.5,1189.9,262.7,1189.7,263,1189.7L263,1189.7z" overflow="visible" />
                            </clipPath>
                            <rect x="260.4" y="1187.6" clipPath="url(#SVGID_126_)" fill="#FFFFFF" width="5.3" height="11.5" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_127_" x="251" y="1182.8" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_128_" d="M264.6,1189.7L264.6,1189.7L264.6,1189.7c0.3,0,0.6,0.3,0.6,0.6v6.2l0,0c0,0.3-0.3,0.6-0.6,0.6l0,0l0,0 c-0.3,0-0.6-0.3-0.6-0.6v-6.2l0,0C264.1,1189.9,264.3,1189.7,264.6,1189.7L264.6,1189.7z" />
                            </defs>
                            <clipPath id="SVGID_129_">
                                <rect x="251" y="1182.8" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_130_" clipPath="url(#SVGID_129_)">
                                <path d="M264.6,1189.7L264.6,1189.7L264.6,1189.7c0.3,0,0.6,0.3,0.6,0.6v6.2l0,0c0,0.3-0.3,0.6-0.6,0.6l0,0l0,0 c-0.3,0-0.6-0.3-0.6-0.6v-6.2l0,0C264.1,1189.9,264.3,1189.7,264.6,1189.7L264.6,1189.7z" overflow="visible" />
                            </clipPath>
                            <rect x="262" y="1187.6" clipPath="url(#SVGID_130_)" fill="#FFFFFF" width="5.3" height="11.5" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_131_" x="251" y="1182.8" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_132_" d="M265.2,1185.9L265.2,1185.9L265.2,1185.9c0.2-0.1,0.5,0,0.6,0.3l1.2,3.2l0,0c0.1,0.2,0,0.5-0.3,0.6l0,0 l0,0c-0.2,0.1-0.5,0-0.6-0.3l-1.2-3.2l0,0C264.8,1186.2,265,1186,265.2,1185.9L265.2,1185.9z" />
                            </defs>
                            <clipPath id="SVGID_133_">
                                <rect x="251" y="1182.8" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_134_" clipPath="url(#SVGID_133_)">
                                <path d="M265.2,1185.9L265.2,1185.9L265.2,1185.9c0.2-0.1,0.5,0,0.6,0.3l1.2,3.2l0,0c0.1,0.2,0,0.5-0.3,0.6l0,0 l0,0c-0.2,0.1-0.5,0-0.6-0.3l-1.2-3.2l0,0C264.8,1186.2,265,1186,265.2,1185.9L265.2,1185.9z" overflow="visible" />
                            </clipPath>
                            <rect x="263.4" y="1183.7" transform="matrix(0.9398 -0.3418 0.3418 0.9398 -390.0586 162.4706)" clipPath="url(#SVGID_134_)" fill="#FFFFFF" width="5.1" height="8.5" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_135_" x="251" y="1182.8" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_136_" d="M262.4,1185.8h2.8l0,0c0.2,0,0.4,0.2,0.4,0.4c0,0,0,0,0,0l-0.2,4.7l0,0c0,0.2-0.2,0.4-0.4,0.4h-2.4l0,0 c-0.2,0-0.4-0.2-0.4-0.4l-0.2-4.7l0,0C262,1186,262.2,1185.8,262.4,1185.8C262.4,1185.8,262.4,1185.8,262.4,1185.8L262.4,1185.8 z" />
                            </defs>
                            <clipPath id="SVGID_137_">
                                <rect x="251" y="1182.8" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_138_" clipPath="url(#SVGID_137_)">
                                <path d="M262.4,1185.8h2.8l0,0c0.2,0,0.4,0.2,0.4,0.4c0,0,0,0,0,0l-0.2,4.7l0,0c0,0.2-0.2,0.4-0.4,0.4h-2.4l0,0 c-0.2,0-0.4-0.2-0.4-0.4l-0.2-4.7l0,0C262,1186,262.2,1185.8,262.4,1185.8C262.4,1185.8,262.4,1185.8,262.4,1185.8L262.4,1185.8 z" overflow="visible" />
                            </clipPath>
                            <rect x="259.9" y="1183.7" clipPath="url(#SVGID_138_)" fill="#FFFFFF" width="7.8" height="9.7" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_139_" x="251" y="1182.8" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_140_" d="M264,1185.3c0.7,0,1.3-0.6,1.3-1.3c0-0.7-0.6-1.3-1.3-1.3c-0.7,0-1.3,0.6-1.3,1.3 C262.7,1184.7,263.3,1185.3,264,1185.3L264,1185.3z" />
                            </defs>
                            <clipPath id="SVGID_141_">
                                <rect x="251" y="1182.8" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_142_" clipPath="url(#SVGID_141_)">
                                <path d="M264,1185.3c0.7,0,1.3-0.6,1.3-1.3c0-0.7-0.6-1.3-1.3-1.3c-0.7,0-1.3,0.6-1.3,1.3 C262.7,1184.7,263.3,1185.3,264,1185.3L264,1185.3z" overflow="visible" />
                            </clipPath>
                            <rect x="260.6" y="1180.7" clipPath="url(#SVGID_142_)" fill="#FFFFFF" width="6.7" height="6.7" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_143_" x="258.8" y="1182.8" width="0.7" height="14.4" />
                            </defs>
                            <clipPath id="SVGID_144_">
                                <rect x="258.8" y="1182.8" width="0.7" height="14.4" overflow="visible" />
                            </clipPath>
                            <rect x="256.7" y="1180.7" clipPath="url(#SVGID_144_)" fill="#FFFFFF" width="4.8" height="18.6" />
                        </g>
                    </g>
                    <g>
                        <defs>
                            <path id="SVGID_145_" d="M196.9,1173.8h-62.3c-0.5,0-0.9,0.4-0.9,0.9l0.3,20.8l2.2,9.9c0,0.5,0.4,0.9,0.9,0.9h59.8 c0.5,0,0.9-0.4,0.9-0.9v-30.7C197.8,1174.2,197.4,1173.8,196.9,1173.8L196.9,1173.8z" />
                        </defs>
                        <path d="M196.9,1173.8h-62.3c-0.5,0-0.9,0.4-0.9,0.9l0.3,20.8l2.2,9.9c0,0.5,0.4,0.9,0.9,0.9h59.8 c0.5,0,0.9-0.4,0.9-0.9v-30.7C197.8,1174.2,197.4,1173.8,196.9,1173.8L196.9,1173.8z" overflow="visible" fill-rule="evenodd" clip-rule="evenodd" fill="#2DB4D0" />
                    </g>
                    <g>
                        <g>
                            <defs>
                                <rect id="SVGID_147_" x="157.7" y="1182.8" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_148_" d="M159.6,1185.9L159.6,1185.9L159.6,1185.9c0.2,0.1,0.4,0.4,0.3,0.6l-1.2,3.2l0,0 c-0.1,0.2-0.3,0.4-0.6,0.3l0,0l0,0c-0.2-0.1-0.4-0.3-0.3-0.6l1.2-3.2l0,0C159.1,1185.9,159.4,1185.8,159.6,1185.9L159.6,1185.9z " />
                            </defs>
                            <clipPath id="SVGID_149_">
                                <rect x="157.7" y="1182.8" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_150_" clipPath="url(#SVGID_149_)">
                                <path d="M159.6,1185.9L159.6,1185.9L159.6,1185.9c0.2,0.1,0.4,0.4,0.3,0.6l-1.2,3.2l0,0 c-0.1,0.2-0.3,0.4-0.6,0.3l0,0l0,0c-0.2-0.1-0.4-0.3-0.3-0.6l1.2-3.2l0,0C159.1,1185.9,159.4,1185.8,159.6,1185.9L159.6,1185.9z " overflow="visible" />
                            </clipPath>
                            <rect x="154.6" y="1185.4" transform="matrix(0.3419 -0.9397 0.9397 0.3419 -1011.7885 931.0352)" clipPath="url(#SVGID_150_)" fill="#FFFFFF" width="8.5" height="5.1" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_151_" x="157.7" y="1182.8" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_152_" d="M160.1,1191.9L160.1,1191.9L160.1,1191.9c0.3,0,0.6,0.3,0.6,0.6v3.9l0,0c0,0.3-0.3,0.6-0.6,0.6l0,0l0,0 c-0.3,0-0.6-0.3-0.6-0.6v-3.9l0,0C159.5,1192.2,159.8,1191.9,160.1,1191.9L160.1,1191.9z" />
                            </defs>
                            <clipPath id="SVGID_153_">
                                <rect x="157.7" y="1182.8" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_154_" clipPath="url(#SVGID_153_)">
                                <path d="M160.1,1191.9L160.1,1191.9L160.1,1191.9c0.3,0,0.6,0.3,0.6,0.6v3.9l0,0c0,0.3-0.3,0.6-0.6,0.6l0,0l0,0 c-0.3,0-0.6-0.3-0.6-0.6v-3.9l0,0C159.5,1192.2,159.8,1191.9,160.1,1191.9L160.1,1191.9z" overflow="visible" />
                            </clipPath>
                            <rect x="157.4" y="1189.9" clipPath="url(#SVGID_154_)" fill="#FFFFFF" width="5.3" height="9.2" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_155_" x="157.7" y="1182.8" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_156_" d="M161.7,1191.9L161.7,1191.9L161.7,1191.9c0.3,0,0.6,0.3,0.6,0.6v3.9l0,0c0,0.3-0.3,0.6-0.6,0.6l0,0l0,0 c-0.3,0-0.6-0.3-0.6-0.6v-3.9l0,0C161.1,1192.2,161.4,1191.9,161.7,1191.9L161.7,1191.9z" />
                            </defs>
                            <clipPath id="SVGID_157_">
                                <rect x="157.7" y="1182.8" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_158_" clipPath="url(#SVGID_157_)">
                                <path d="M161.7,1191.9L161.7,1191.9L161.7,1191.9c0.3,0,0.6,0.3,0.6,0.6v3.9l0,0c0,0.3-0.3,0.6-0.6,0.6l0,0l0,0 c-0.3,0-0.6-0.3-0.6-0.6v-3.9l0,0C161.1,1192.2,161.4,1191.9,161.7,1191.9L161.7,1191.9z" overflow="visible" />
                            </clipPath>
                            <rect x="159" y="1189.9" clipPath="url(#SVGID_158_)" fill="#FFFFFF" width="5.3" height="9.2" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_159_" x="157.7" y="1182.8" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_160_" d="M162.2,1185.9L162.2,1185.9L162.2,1185.9c0.2-0.1,0.5,0,0.6,0.3l1.2,3.2l0,0c0.1,0.2,0,0.5-0.3,0.6l0,0 l0,0c-0.2,0.1-0.5,0-0.6-0.3l-1.2-3.2l0,0C161.9,1186.2,162,1186,162.2,1185.9L162.2,1185.9z" />
                            </defs>
                            <clipPath id="SVGID_161_">
                                <rect x="157.7" y="1182.8" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_162_" clipPath="url(#SVGID_161_)">
                                <path d="M162.2,1185.9L162.2,1185.9L162.2,1185.9c0.2-0.1,0.5,0,0.6,0.3l1.2,3.2l0,0c0.1,0.2,0,0.5-0.3,0.6l0,0 l0,0c-0.2,0.1-0.5,0-0.6-0.3l-1.2-3.2l0,0C161.9,1186.2,162,1186,162.2,1185.9L162.2,1185.9z" overflow="visible" />
                            </clipPath>
                            <rect x="160.4" y="1183.7" transform="matrix(0.9398 -0.3418 0.3418 0.9398 -396.2445 127.2674)" clipPath="url(#SVGID_162_)" fill="#FFFFFF" width="5.1" height="8.5" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_163_" x="157.7" y="1182.8" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_164_" d="M159.5,1185.8h2.7l0,0c0.2,0,0.4,0.2,0.4,0.4c0,0,0,0,0,0.1l-0.4,3.2h-2.8l-0.4-3.2l0,0 C159.1,1186,159.2,1185.8,159.5,1185.8C159.5,1185.8,159.5,1185.8,159.5,1185.8L159.5,1185.8z" />
                            </defs>
                            <clipPath id="SVGID_165_">
                                <rect x="157.7" y="1182.8" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_166_" clipPath="url(#SVGID_165_)">
                                <path d="M159.5,1185.8h2.7l0,0c0.2,0,0.4,0.2,0.4,0.4c0,0,0,0,0,0.1l-0.4,3.2h-2.8l-0.4-3.2l0,0 C159.1,1186,159.2,1185.8,159.5,1185.8C159.5,1185.8,159.5,1185.8,159.5,1185.8L159.5,1185.8z" overflow="visible" />
                            </clipPath>
                            <rect x="157" y="1183.7" clipPath="url(#SVGID_166_)" fill="#FFFFFF" width="7.7" height="7.8" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_167_" x="157.7" y="1182.8" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_168_" d="M159.1,1192.4h3.5l0,0c0.2,0,0.4-0.2,0.4-0.4c0,0,0-0.1,0-0.1l-0.8-3.2h-2.8l-0.8,3.2l0,0 C158.7,1192.1,158.8,1192.3,159.1,1192.4C159.1,1192.4,159.1,1192.4,159.1,1192.4L159.1,1192.4z" />
                            </defs>
                            <clipPath id="SVGID_169_">
                                <rect x="157.7" y="1182.8" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_170_" clipPath="url(#SVGID_169_)">
                                <path d="M159.1,1192.4h3.5l0,0c0.2,0,0.4-0.2,0.4-0.4c0,0,0-0.1,0-0.1l-0.8-3.2h-2.8l-0.8,3.2l0,0 C158.7,1192.1,158.8,1192.3,159.1,1192.4C159.1,1192.4,159.1,1192.4,159.1,1192.4L159.1,1192.4z" overflow="visible" />
                            </clipPath>
                            <rect x="156.6" y="1186.7" clipPath="url(#SVGID_170_)" fill="#FFFFFF" width="8.5" height="7.8" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_171_" x="157.7" y="1182.8" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_172_" d="M161,1185.3c0.7,0,1.3-0.6,1.3-1.3c0-0.7-0.6-1.3-1.3-1.3c-0.7,0-1.3,0.6-1.3,1.3 C159.7,1184.7,160.3,1185.3,161,1185.3L161,1185.3z" />
                            </defs>
                            <clipPath id="SVGID_173_">
                                <rect x="157.7" y="1182.8" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_174_" clipPath="url(#SVGID_173_)">
                                <path d="M161,1185.3c0.7,0,1.3-0.6,1.3-1.3c0-0.7-0.6-1.3-1.3-1.3c-0.7,0-1.3,0.6-1.3,1.3 C159.7,1184.7,160.3,1185.3,161,1185.3L161,1185.3z" overflow="visible" />
                            </clipPath>
                            <rect x="157.7" y="1180.7" clipPath="url(#SVGID_174_)" fill="#FFFFFF" width="6.7" height="6.7" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_175_" x="157.7" y="1182.8" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_176_" d="M169.2,1185.9L169.2,1185.9L169.2,1185.9c0.2,0.1,0.4,0.4,0.3,0.6l-1.2,3.2l0,0 c-0.1,0.2-0.3,0.4-0.6,0.3l0,0l0,0c-0.2-0.1-0.4-0.3-0.3-0.6l1.2-3.2l0,0C168.7,1185.9,169,1185.8,169.2,1185.9L169.2,1185.9z" />
                            </defs>
                            <clipPath id="SVGID_177_">
                                <rect x="157.7" y="1182.8" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_178_" clipPath="url(#SVGID_177_)">
                                <path d="M169.2,1185.9L169.2,1185.9L169.2,1185.9c0.2,0.1,0.4,0.4,0.3,0.6l-1.2,3.2l0,0 c-0.1,0.2-0.3,0.4-0.6,0.3l0,0l0,0c-0.2-0.1-0.4-0.3-0.3-0.6l1.2-3.2l0,0C168.7,1185.9,169,1185.8,169.2,1185.9L169.2,1185.9z" overflow="visible" />
                            </clipPath>
                            <rect x="164.2" y="1185.4" transform="matrix(0.3418 -0.9398 0.9398 0.3418 -1005.4867 940.2645)" clipPath="url(#SVGID_178_)" fill="#FFFFFF" width="8.5" height="5.1" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_179_" x="157.7" y="1182.8" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_180_" d="M169.7,1189.7L169.7,1189.7L169.7,1189.7c0.3,0,0.6,0.3,0.6,0.6v6.2l0,0c0,0.3-0.3,0.6-0.6,0.6l0,0l0,0 c-0.3,0-0.6-0.3-0.6-0.6v-6.2l0,0C169.1,1189.9,169.4,1189.7,169.7,1189.7L169.7,1189.7z" />
                            </defs>
                            <clipPath id="SVGID_181_">
                                <rect x="157.7" y="1182.8" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_182_" clipPath="url(#SVGID_181_)">
                                <path d="M169.7,1189.7L169.7,1189.7L169.7,1189.7c0.3,0,0.6,0.3,0.6,0.6v6.2l0,0c0,0.3-0.3,0.6-0.6,0.6l0,0l0,0 c-0.3,0-0.6-0.3-0.6-0.6v-6.2l0,0C169.1,1189.9,169.4,1189.7,169.7,1189.7L169.7,1189.7z" overflow="visible" />
                            </clipPath>
                            <rect x="167.1" y="1187.6" clipPath="url(#SVGID_182_)" fill="#FFFFFF" width="5.3" height="11.5" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_183_" x="157.7" y="1182.8" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_184_" d="M171.3,1189.7L171.3,1189.7L171.3,1189.7c0.3,0,0.6,0.3,0.6,0.6v6.2l0,0c0,0.3-0.3,0.6-0.6,0.6l0,0l0,0 c-0.3,0-0.6-0.3-0.6-0.6v-6.2l0,0C170.7,1189.9,171,1189.7,171.3,1189.7L171.3,1189.7z" />
                            </defs>
                            <clipPath id="SVGID_185_">
                                <rect x="157.7" y="1182.8" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_186_" clipPath="url(#SVGID_185_)">
                                <path d="M171.3,1189.7L171.3,1189.7L171.3,1189.7c0.3,0,0.6,0.3,0.6,0.6v6.2l0,0c0,0.3-0.3,0.6-0.6,0.6l0,0l0,0 c-0.3,0-0.6-0.3-0.6-0.6v-6.2l0,0C170.7,1189.9,171,1189.7,171.3,1189.7L171.3,1189.7z" overflow="visible" />
                            </clipPath>
                            <rect x="168.7" y="1187.6" clipPath="url(#SVGID_186_)" fill="#FFFFFF" width="5.3" height="11.5" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_187_" x="157.7" y="1182.8" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_188_" d="M171.9,1185.9L171.9,1185.9L171.9,1185.9c0.2-0.1,0.5,0,0.6,0.3l1.2,3.2l0,0c0.1,0.2,0,0.5-0.3,0.6l0,0 l0,0c-0.2,0.1-0.5,0-0.6-0.3l-1.2-3.2l0,0C171.5,1186.2,171.6,1186,171.9,1185.9L171.9,1185.9z" />
                            </defs>
                            <clipPath id="SVGID_189_">
                                <rect x="157.7" y="1182.8" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_190_" clipPath="url(#SVGID_189_)">
                                <path d="M171.9,1185.9L171.9,1185.9L171.9,1185.9c0.2-0.1,0.5,0,0.6,0.3l1.2,3.2l0,0c0.1,0.2,0,0.5-0.3,0.6l0,0 l0,0c-0.2,0.1-0.5,0-0.6-0.3l-1.2-3.2l0,0C171.5,1186.2,171.6,1186,171.9,1185.9L171.9,1185.9z" overflow="visible" />
                            </clipPath>
                            <rect x="170.1" y="1183.7" transform="matrix(0.9398 -0.3418 0.3418 0.9398 -395.6806 130.5688)" clipPath="url(#SVGID_190_)" fill="#FFFFFF" width="5.1" height="8.5" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_191_" x="157.7" y="1182.8" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_192_" d="M169.1,1185.8h2.8l0,0c0.2,0,0.4,0.2,0.4,0.4c0,0,0,0,0,0l-0.2,4.7l0,0c0,0.2-0.2,0.4-0.4,0.4h-2.4l0,0 c-0.2,0-0.4-0.2-0.4-0.4l-0.2-4.7l0,0C168.7,1186,168.9,1185.8,169.1,1185.8C169.1,1185.8,169.1,1185.8,169.1,1185.8 L169.1,1185.8z" />
                            </defs>
                            <clipPath id="SVGID_193_">
                                <rect x="157.7" y="1182.8" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_194_" clipPath="url(#SVGID_193_)">
                                <path d="M169.1,1185.8h2.8l0,0c0.2,0,0.4,0.2,0.4,0.4c0,0,0,0,0,0l-0.2,4.7l0,0c0,0.2-0.2,0.4-0.4,0.4h-2.4l0,0 c-0.2,0-0.4-0.2-0.4-0.4l-0.2-4.7l0,0C168.7,1186,168.9,1185.8,169.1,1185.8C169.1,1185.8,169.1,1185.8,169.1,1185.8 L169.1,1185.8z" overflow="visible" />
                            </clipPath>
                            <rect x="166.6" y="1183.7" clipPath="url(#SVGID_194_)" fill="#FFFFFF" width="7.8" height="9.7" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_195_" x="157.7" y="1182.8" width="16.2" height="14.5" />
                            </defs>
                            <defs>
                                <path id="SVGID_196_" d="M170.6,1185.3c0.7,0,1.3-0.6,1.3-1.3c0-0.7-0.6-1.3-1.3-1.3c-0.7,0-1.3,0.6-1.3,1.3 C169.4,1184.7,169.9,1185.3,170.6,1185.3L170.6,1185.3z" />
                            </defs>
                            <clipPath id="SVGID_197_">
                                <rect x="157.7" y="1182.8" width="16.2" height="14.5" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_198_" clipPath="url(#SVGID_197_)">
                                <path d="M170.6,1185.3c0.7,0,1.3-0.6,1.3-1.3c0-0.7-0.6-1.3-1.3-1.3c-0.7,0-1.3,0.6-1.3,1.3 C169.4,1184.7,169.9,1185.3,170.6,1185.3L170.6,1185.3z" overflow="visible" />
                            </clipPath>
                            <rect x="167.3" y="1180.7" clipPath="url(#SVGID_198_)" fill="#FFFFFF" width="6.7" height="6.7" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_199_" x="165.5" y="1182.8" width="0.7" height="14.4" />
                            </defs>
                            <clipPath id="SVGID_200_">
                                <rect x="165.5" y="1182.8" width="0.7" height="14.4" overflow="visible" />
                            </clipPath>
                            <rect x="163.4" y="1180.7" clipPath="url(#SVGID_200_)" fill="#FFFFFF" width="4.8" height="18.6" />
                        </g>
                    </g>
                    <g>
                        <defs>
                            <path id="SVGID_201_" d="M150.5,1256.1h124.1c0.5,0,0.9,0.4,0.9,0.9c0,0-21,85.6-63.1,85.6s-62.8-85.6-62.8-85.6 C149.5,1256.5,150,1256.1,150.5,1256.1L150.5,1256.1z" />
                        </defs>
                        <path d="M150.5,1256.1h124.1c0.5,0,0.9,0.4,0.9,0.9c0,0-21,85.6-63.1,85.6s-62.8-85.6-62.8-85.6 C149.5,1256.5,150,1256.1,150.5,1256.1L150.5,1256.1z" overflow="visible" fill-rule="evenodd" clip-rule="evenodd" fill="#2DB4D0" />
                    </g>
                    <g>
                        <g>
                            <defs>
                                <rect id="SVGID_203_" x="205.9" y="1285.1" width="13.1" height="7.7" />
                            </defs>
                            <defs>
                                <path id="SVGID_204_" d="M212,1292.8c3.4,0,6.1-0.3,6.1-0.6c0-0.4-2.7-0.6-6.1-0.6c-3.4,0-6.1,0.3-6.1,0.6 C205.9,1292.5,208.7,1292.8,212,1292.8L212,1292.8z" />
                            </defs>
                            <clipPath id="SVGID_205_">
                                <rect x="205.9" y="1285.1" width="13.1" height="7.7" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_206_" clipPath="url(#SVGID_205_)">
                                <path d="M212,1292.8c3.4,0,6.1-0.3,6.1-0.6c0-0.4-2.7-0.6-6.1-0.6c-3.4,0-6.1,0.3-6.1,0.6 C205.9,1292.5,208.7,1292.8,212,1292.8L212,1292.8z" overflow="visible" />
                            </clipPath>
                            <rect x="204.3" y="1289.9" clipPath="url(#SVGID_206_)" fill="#FFFFFF" width="15.3" height="4.5" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_207_" x="205.9" y="1285.1" width="13.1" height="7.7" />
                            </defs>
                            <defs>
                                <path id="SVGID_208_" d="M208.1,1285.1h7.8l0,0c0.2,0,0.3,0.1,0.3,0.3c0.3,1.4,0.4,2.6,0.3,3.6c-0.1,1-0.6,2.1-1.5,3.1l0,0 c-0.1,0.1-0.1,0.1-0.2,0.1h-5.5l0,0c-0.1,0-0.2,0-0.2-0.1c-0.9-0.8-1.4-1.9-1.5-3.1c-0.1-1.2,0-2.4,0.3-3.6l0,0 C207.8,1285.2,208,1285.1,208.1,1285.1L208.1,1285.1z" />
                            </defs>
                            <clipPath id="SVGID_209_">
                                <rect x="205.9" y="1285.1" width="13.1" height="7.7" overflow="visible" />
                            </clipPath>
                            <clipPath id="SVGID_210_" clipPath="url(#SVGID_209_)">
                                <path d="M208.1,1285.1h7.8l0,0c0.2,0,0.3,0.1,0.3,0.3c0.3,1.4,0.4,2.6,0.3,3.6c-0.1,1-0.6,2.1-1.5,3.1l0,0 c-0.1,0.1-0.1,0.1-0.2,0.1h-5.5l0,0c-0.1,0-0.2,0-0.2-0.1c-0.9-0.8-1.4-1.9-1.5-3.1c-0.1-1.2,0-2.4,0.3-3.6l0,0 C207.8,1285.2,208,1285.1,208.1,1285.1L208.1,1285.1z" overflow="visible" />
                            </clipPath>
                            <rect x="205.9" y="1283.5" clipPath="url(#SVGID_210_)" fill="#FFFFFF" width="12.2" height="10.2" />
                        </g>
                        <g>
                            <defs>
                                <rect id="SVGID_211_" x="205.9" y="1285.1" width="13.1" height="7.7" />
                            </defs>
                            <clipPath id="SVGID_212_">
                                <rect x="205.9" y="1285.1" width="13.1" height="7.7" overflow="visible" />
                            </clipPath>
                            <path clipPath="url(#SVGID_212_)" fill="#FFFFFF" d="M217.1,1290.6c-1.1,0-1.9-0.9-1.9-1.9c0-1.1,0.9-1.9,1.9-1.9 c1.1,0,1.9,0.9,1.9,1.9C219.1,1289.7,218.2,1290.6,217.1,1290.6z M217.1,1287.4c-0.7,0-1.3,0.6-1.3,1.3c0,0.7,0.6,1.3,1.3,1.3 c0.7,0,1.3-0.6,1.3-1.3C218.4,1287.9,217.8,1287.4,217.1,1287.4z" />
                        </g>
                    </g>
                    <path fill="#F3F3F3" d="M288.2,213.3H231c-0.8,0-1.5-0.7-1.5-1.5c0-0.8,0.7-1.5,1.5-1.5h57.2" />
                    <path fill="#F3F3F3" d="M135.3,213.3h57.2c0.8,0,1.5-0.7,1.5-1.5c0-0.8-0.7-1.5-1.5-1.5h-57.2" />
                    <path fill="#F3F3F3" d="M292.3,390.2h-61.8c-0.8,0-1.5-0.7-1.5-1.5c0-0.8,0.7-1.5,1.5-1.5h61.8" />
                    <path fill="#F3F3F3" d="M132.1,390.2h61.8c0.8,0,1.5-0.7,1.5-1.5c0-0.8-0.7-1.5-1.5-1.5h-61.8" />
                </g>
                {places}
            </g>
            <text style={{ whiteSpace: "pre", fill: "rgb(51, 51, 51)", fontFamily: "Arial, sans-serif", fontSize: "17.9" }} x="218.357" y="279.189">A</text>
            <text style={{ whiteSpace: "pre", fill: "rgb(51, 51, 51)", fontFamily: "Arial, sans-serif", fontSize: "17.9" }} x="218.357" y="247.129">B</text>
            <text style={{ fontFamily: "Roboto", fontSize: "17.9", whiteSpace: "pre" }} x="218.255" y="191.604">C</text>
            <text style={{ fontFamily: "Roboto", fontSize: "17.9", whiteSpace: "pre" }} x="218.471" y="159.747">D</text>
            <text style={{ whiteSpace: "pre", fill: "rgb(51, 51, 51)", fontFamily: "Arial, sans-serif", fontSize: "8.5" }} x="399.005" y="280.385">A</text>
            <text style={{ whiteSpace: "pre", fill: "rgb(51, 51, 51)", fontFamily: "Arial, sans-serif", fontSize: "8.5" }} x="398.702" y="257.875">B</text>
            <text style={{ whiteSpace: "pre", fill: "rgb(51, 51, 51)", fontFamily: "Arial, sans-serif", fontSize: "8.5" }} x="398.609" y="234.61">C</text>
            <text style={{ whiteSpace: "pre", fill: "rgb(51, 51, 51)", fontFamily: "Arial, sans-serif", fontSize: "8.5" }} x="397.796" y="195.633">D</text>
            <text style={{ whiteSpace: "pre", fill: "rgb(51, 51, 51)", fontFamily: "Arial, sans-serif", fontSize: "8.5" }} x="397.796" y="172.972">E</text>
            <text style={{ whiteSpace: "pre", fill: "rgb(51, 51, 51)", fontFamily: "Arial, sans-serif", fontSize: "8.5" }} x="397.796" y="150.312">F</text>
            <text style={{ fill: "rgb(51, 51, 51)", fontFamily: "Arial, sans-serif", fontSize: "12", whiteSpace: "pre" }} x="244.821" y="216.837">01      02      03       04                 05     06     07     08      09     10     11      17     18      19     20     21     22     23      24     25      26     27     28      29     30     31     32      33</text>
        </svg>
    );
});