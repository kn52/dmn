package Day43;

public class ContainerWithMostWater {

	public static void main(String[] args) {
		int ans = maxArea(new int[] { 1, 5, 4, 3 });
		System.out.println(ans);
	}
	public static int maxArea(int[] A) {
        int L = 0;
        int R = A.length - 1;
        int ans = 0;
        while (L < R) {
            int height = A[L] > A[R] ? A[R] : A[L];
            int volume = (R - L) * height;
            if (ans < volume) {
                ans = volume;
            }
            if (A[L] > A[R]) {
                R--;
            }
            else {
                L++;
            }
        } 
        return ans;
    }
}
